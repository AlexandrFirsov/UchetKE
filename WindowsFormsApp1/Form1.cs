using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using UchetCT.models;
using WindowsFormsApp1;


namespace UchetCT
{
    enum rowState
    {
        Existdet,
        New,
        Modified,
        ModifiedView,
        Deleted
    }
    public partial class Form1 : Form
    {
        static DB dB = new DB();

        int selectedRow;
        AutorizationForm autorizationForm;
        public Form1(AutorizationForm autorizationForm)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.autorizationForm = autorizationForm;
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }
        private void CreateColumnsEquipment(DataGridView dgv)
        {
            dgv.Columns.Add("number", "Инвентарный номер");
#pragma warning disable CA1416 // Проверка совместимости платформы
            dgv.Columns.Add("id", "id");
#pragma warning restore CA1416 // Проверка совместимости платформы
            dgv.Columns.Add("name_of", "Наименование");
            dgv.Columns.Add("quanity", "Количество");
            dgv.Columns.Add("type_of", "Тип");
            //dgv.Columns.Add("response_pers", "Ответственное лицо");
            //dgv.Columns.Add("IsNew", String.Empty);
        }
        private void CreateColumnsResponsePerson(DataGridView dgv)
        {
#pragma warning disable CA1416 // Проверка совместимости платформы
            dgv.Columns.Add("id", "id");
#pragma warning restore CA1416 // Проверка совместимости платформы
            dgv.Columns.Add("name", "Имя");
            dgv.Columns.Add("lastname", "Фамилия");
            dgv.Columns.Add("surname", "Отчество");
            dgv.Columns.Add("birthdate", "Дата рождения");
            dgv.Columns.Add("post", "Должность");
            dgv.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRows(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetInt32(3), record.GetString(4));
        }

        private void ReadSingleRowsAnother(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetDateTime(4), record.GetString(5));
        }
        private void comboBox1_Click(object sender, EventArgs e)
        {
        }

        private void RefreshDataGridAnother(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string query = @"select * from respons_person";

            SqlCommand command = new SqlCommand(query, dB.getConnection());

            dB.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowsAnother(dgv, reader);
            }
            reader.Close();
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                dB.closeConnection();
                this.Visible = false;
                autorizationForm.Visible = true;
            }
            else
            {
                this.Close();
                Form1 form1 = new Form1(autorizationForm);
                form1.Visible = true;
            }

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            using (MyDBEnt db = new MyDBEnt())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var query = from users in db.respons_person select users;
                comboBox1.DataSource = db.respons_person.ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "lastname";

            }
            //CreateColumnsEquipment(dataGridView1);
            //RefreshDataGrid(dataGridView1);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void btn_NewNote_Click(object sender, EventArgs e)
        {
        }
        private void Search(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string SearchString = $"select * from equipment where concat(id, name_of, quantity, type_of, respons_pers) like '%" + textBox_Search.Text + "%'";
            SqlCommand command = new SqlCommand(SearchString, dB.getConnection());
            dB.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRows(dgv, reader);
            }

            reader.Close();
        }
        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }
        private void tabUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void tabUsers_Click(object sender, EventArgs e)
        {
            CreateColumnsResponsePerson(dataGridView2);
            RefreshDataGridAnother(dataGridView2);
        }
        private void dataGridView2_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void label11_Click(object sender, EventArgs e)
        {

        }
        private void buttonNewNote_Click(object sender, EventArgs e)
        {
            AddUsers addUsers = new AddUsers(this);
            addUsers.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dataGridView1.Update();
        }

        private void StripMenuItemRemoveNote_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedrows = dataGridView1.SelectedRows;
            if (selectedrows.Count > 0)
            {
                /**var column = dataGridView1[1, 1].Selected;
                using(MyDBEnt db = new MyDBEnt())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    try
                    {
                        var query = db.equipment.Where(u => u.id == column)
                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message); }
                }
                foreach(var selected in selectedrows)
                {
                    var query = $"delete from equipment" +
                        $"where number = {selected.column}";
                }*/
            }
            /**dB.openConnection();


            if(dataGridView1.SelectedRows.Count > 0)
            {
                DataSet
                for (int j = 0; j < dataGridView1.SelectedRows.Count; j++)
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        if (dataGridView1.SelectedRows[j] == dataGridView2.Rows[i])
                        {
                            table.Expence.Rows[i].Delete();
                            SqlCeDataAdapter.Update(CinemaDataSet);
                        }
                    }
            }
            else
            {
                MessageBox.Show("Не выбрана не одна строка");
            }
            CinemaDataSet.Tables["Expence"].AcceptChanges();*/

            /**DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;
            foreach (DataGridViewRow selectedRow in selectedRows)
            {
                using (MyDBEnt db = new MyDBEnt())
                {
                    db.Configuration.ProxyCreationEnabled = false;

                    int rowIndex = selectedRow.Index;
                    var SQLQuery = db.equipment.SqlQuery($"delete from equipment where id = {rowIndex}");
                    var sql = $"delete from equipment where id = {rowIndex}";

                    DialogResult dlgConfirm = MessageBox.Show("Удалить эту запись?\r\n\r\n", "Подтвердите", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dlgConfirm == DialogResult.Yes)
                    {
                        DeleteRecordTool(dataGridView1, sql);
                    }
                    dataGridView1.ClearSelection();

                }

            }*/
        }
        private void DeleteRecordTool(DataGridView dgv, string query)
        {


            foreach (DataGridViewRow item in dgv.SelectedRows)
            {
                dgv.Rows.RemoveAt(item.Index);
                SqlCommand sql = new SqlCommand(query, dB.getConnection());
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            TranslateForm translateForm = new TranslateForm(this);
            translateForm.Visible = true;
            this.Visible = false;
        }

        private void ToolStripMenuItemCancellation_Click(object sender, EventArgs e)
        {
            Списание списание = new Списание(this);
            списание.Visible = true;
            this.Visible = false;
        }

        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            AddForm add = new AddForm(this);
            add.Show();
            this.Hide();
        }

        private void оборудованиеНаСкладеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Склад склад = new Склад(this);
            склад.Visible = true;
            this.Visible = false;
        }

        private void переводОборудованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TranslateForm translate = new TranslateForm(this);
            translate.Visible = true;
            this.Visible = false;
        }

        private void поступлениеОборудованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm add = new AddForm(this);
            this.Hide();
            add.Show();
        }

        private void списаниеОборудованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Списание списание = new Списание(this);
            списание.Visible = true;
            this.Visible = false;
        }

        private void отчетОПользователяхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users users = new Users(this);
            users.Visible = true;
            this.Hide();
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void переводОборудованияВНеактивToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void снятиеСБалансаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void принятиеНовогоСотрудникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUsers addUsers = new AddUsers(this);
            this.Hide();
            addUsers.Show();
        }
    }
}