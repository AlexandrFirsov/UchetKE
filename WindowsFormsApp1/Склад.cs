using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using UchetCT;
using UchetCT.models;

namespace WindowsFormsApp1
{
    public partial class Склад : Form
    {
        DB dB = new DB();
        Form1 form1;
        public Склад(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void ReadSingleRows(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetInt32(3), record.GetString(4));
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

        private void Склад_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
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
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Cursor.Current = Cursors.Default;
        }


        private void RefreshDataGrid(DataGridView dgv)
        {
            try
            {
                dgv.Rows.Clear();
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

        private void Склад_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Visible = false;
                form1.Visible = true;
            }
            else
            {
                Склад склад = new Склад(form1);
                склад.Visible = true;
                this.Close();

            }
        }
    }
}
