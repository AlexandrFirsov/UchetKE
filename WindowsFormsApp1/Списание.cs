using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using UchetCT;
using UchetCT.models;
using Word = Microsoft.Office.Interop.Word;

namespace WindowsFormsApp1
{
    public partial class Списание : Form
    {
        DB dB = new DB();

        Form1 form1;
        public Списание(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void Списание_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            using (MyDBEnt db = new MyDBEnt())
            {
                db.Configuration.ProxyCreationEnabled = false;

                var query = from u in db.equipment
                            join d in db.type_of_equip on u.type_of equals d.id
                            join c in db.respons_person on u.respons_pers equals c.id
                            select new
                            {
                                Номер = u.number,
                                Наименование = u.name_of,
                                Тип = d.type_of,
                                Количество = u.quantity,
                                Цена = u.price,
                            };
                dataGridView1.DataSource = query.ToList();
            }

            //CreateColumnsEquipment(dataGridView1);
            //RefreshDataGrid(dataGridView1);
        }

        private void CreateColumnsEquipment(DataGridView dgv)
        {
            dgv.Columns.Add("number", "Инвентарный номер");
            dgv.Columns.Add("id", "id");
            dgv.Columns.Add("name_of", "Наименование");
            dgv.Columns.Add("quanity", "Количество");
            dgv.Columns.Add("type_of", "Тип");
            //dgv.Columns.Add("response_pers", "Ответственное лицо");
            //dgv.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRows(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetInt32(3), record.GetString(4));
        }

        private void RefreshDataGrid(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string query = $"select number, equipment.id, name_of, quantity, type_of_equip.type_of, (_name +' '+lastname+' '+surname) as FIO from equipment " +
                $"LEFT JOIN respons_person ON respons_person.id = equipment.respons_pers " +
                $"LEFT JOIN type_of_equip ON type_of_equip.id = equipment.type_of ";

            try
            {
                SqlCommand command = new SqlCommand(query, dB.getConnection());

                dB.openConnection();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ReadSingleRows(dgv, reader);
                }
                reader.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }


        private void Списание_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действитильно хотите выйти?", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                form1.Visible = true;
                this.Visible = false;
            }
            else
            {
                Списание списание = new Списание(form1);
                списание.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //var name = dataGridView1.SelectedCells

            var datatable = new DataTable();
            var query = $"select number as Номер, equipment.id as код, name_of as Наименование, quantity as Количество, type_of_equip.type_of as ТипОборудования, (_name +' '+lastname+' '+surname) as ФИО from equipment " +
                $"LEFT JOIN respons_person ON respons_person.id = equipment.respons_pers " +
                $"LEFT JOIN type_of_equip ON type_of_equip.id = equipment.type_of; " +
                $"";
            queryReturnData(query, datatable);
            ExportToWord(datatable);
        }
        public DataTable queryReturnData(string query, DataTable dataTable)
        {
            dB.openConnection();

            SqlDataAdapter SDA = new SqlDataAdapter(query, dB.getConnection());
            SDA.SelectCommand.ExecuteNonQuery();

            SDA.Fill(dataTable);
            return dataTable;
        }
        private void ExportToWord(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                Word.Application word = new Word.Application();
                word.Application.Documents.Add(Type.Missing);

                Word.Table table = word.Application.ActiveDocument.Tables.Add(word.Selection.Range, dataTable.Rows.Count + 1, dataTable.Columns.Count, Type.Missing, Type.Missing);
                table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    table.Cell(1, i + 1).Range.Text = dataTable.Columns[i].ColumnName;
                }

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        table.Cell(i + 2, j + 1).Range.Text = dataTable.Rows[i][j].ToString();
                    }
                }

                word.Visible = true;
            }
            else
            {
                MessageBox.Show("No data to export!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
