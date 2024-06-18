using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using UchetCT;
using UchetCT.models;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.EntityFrameworkCore.SqlServer;
using WindowsFormsApp1.models;
namespace WindowsFormsApp1
{
    public partial class Users : Form
    {
        DB dB = new DB();
        Form1 form1;
        public Users(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }
        private void ReadSingleRows(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetInt32(3), record.GetString(4));
        }


        private void Users_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            using (MyDBEnt db = new MyDBEnt())
            {
                db.Configuration.ProxyCreationEnabled = false;
                comboBox1.DataSource = db.respons_person.ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "lastname";

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

        private void RefreshDataGrid(DataGridView dgv)
        {
            try
            {
                dgv.Rows.Clear();
                //var cbox = comboBox1.SelectedItem.ToString();
                string query = $"select number, equipment.id, name_of, quantity, type_of_equip.type_of, (_name +' '+lastname+' '+surname) as FIO from equipment " +
                $"LEFT JOIN respons_person ON respons_person.id = equipment.respons_pers " +
                $"LEFT JOIN type_of_equip ON type_of_equip.id = equipment.type_of";


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

        private void Users_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                form1.Visible = true;
                this.Visible = false;
            }
            else
            {
                this.Close();
                Users users = new Users(form1);
                users.Show();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            respons_person obj = comboBox1.SelectedItem as respons_person;
            if (obj != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    using (MyDBEnt db = new MyDBEnt())
                    {
                        db.Configuration.ProxyCreationEnabled = false;
                        var query = from u in db.equipment
                                    join d in db.type_of_equip on u.type_of equals d.id
                                    join c in db.respons_person on u.respons_pers equals c.id
                                    where c.id.ToString() == comboBox1.SelectedValue.ToString()
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
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                Cursor.Current = Cursors.Default;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var datatable = new DataTable();
            var query = $"select number as Номер, equipment.id as код, name_of as Наименование, quantity as Количество, type_of_equip.type_of as ТипОборудования, (_name +' '+lastname+' '+surname) as ФИО from equipment " +
                $"LEFT JOIN respons_person ON respons_person.id = equipment.respons_pers " +
                $"LEFT JOIN type_of_equip ON type_of_equip.id = equipment.type_of " +
                $"where respons_person.id = {comboBox1.SelectedValue.ToString()} ;";

            queryReturnData(query, datatable);
            ExportToWord(datatable);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable">Таблица данных</param>
        /// <param name="query">Запрос к базе данных</param>
        /// <returns></returns>
        public DataTable queryReturnData(string query, DataTable dataTable)
        {
            /**try
            {
                using (MyDBEnt db = new MyDBEnt())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    var Sqlquery = from u in db.equipment
                                join d in db.type_of_equip on u.type_of equals d.id
                                join c in db.respons_person on u.respons_pers equals c.id
                                where c.id.ToString() == comboBox1.SelectedValue.ToString()
                                select new
                                {
                                    Номер = u.number,
                                    Наименование = u.name_of,
                                    Тип = d.type_of,
                                    Количество = u.quantity,
                                    Цена = u.price,
                                };
                    var dataset = Sqlquery.ToList();
                    foreach(var items in dataset)
                    {
                        dataTable.Rows.Add(items);
                    }
                }                    

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); } */           
            dB.openConnection();
            SqlDataAdapter SDA = new SqlDataAdapter(query, dB.getConnection());
            SDA.SelectCommand.ExecuteNonQuery();
            SDA.Fill(dataTable);

            return dataTable;
            
        }
        /// <summary>
        /// Метод по переносу данных из таблицы в документ Word
        /// </summary>
        /// <param name="dataTable">Таблица данных</param>
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

    }
}
