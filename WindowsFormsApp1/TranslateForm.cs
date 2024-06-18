using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using UchetCT;
using UchetCT.models;
using Application = System.Windows.Forms.Application;
using ComboBox = System.Windows.Forms.ComboBox;
using Word = Microsoft.Office.Interop.Word;


namespace WindowsFormsApp1
{
    public partial class TranslateForm : Form
    {
        DB dB = new DB();
        Form1 Form1;
        public TranslateForm(Form1 form1)
        {
            InitializeComponent();
            this.Form1 = form1;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void TranslateForm_Load(object sender, EventArgs e)
        {

            using (MyDBEnt db = new MyDBEnt())
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                db.Configuration.ProxyCreationEnabled = false;
                comboBoxReceiver.DataSource = db.respons_person.ToList();
                comboBoxReceiver.ValueMember = "id";
                comboBoxReceiver.DisplayMember = "lastname";

            }


            using (MyDBEnt db = new MyDBEnt())
            {
                db.Configuration.ProxyCreationEnabled = false;
                comboBoxSender.DataSource = db.respons_person.ToList();
                comboBoxSender.ValueMember = "id";
                comboBoxSender.DisplayMember = "lastname";

            }


            CreateColumnsEquipment(dataGridView1);
            RefreshDataGrid(dataGridView1, comboBoxSender);
            CreateColumnsEquipment(dataGridView2);
            RefreshDataGrid(dataGridView2, comboBoxSender);
        }

        private void CreateColumnsEquipment(DataGridView dgv)
        {
            dgv.Columns.Add("id", "id");
            dgv.Columns.Add("name_of", "Наименование");
            dgv.Columns.Add("quanity", "Количество");
            dgv.Columns.Add("type_of", "Тип");
            dgv.Columns.Add("response_pers", "Ответственное лицо");
            dgv.Columns.Add("IsNew", String.Empty);

        }


        private void ReadSingleRows(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetString(3), record.GetString(4));
        }

        private void RefreshDataGrid(DataGridView dgv, ComboBox box)
        {
            var cbox = box.SelectedItem;

            dgv.Rows.Clear();
            string query = $"select equipment.id, name_of, quantity, type_of_equip.type_of, (_name +' '+lastname+' '+surname) as FIO from equipment " +
                $"LEFT JOIN respons_person ON respons_person.id = equipment.respons_pers " +
                $"LEFT JOIN type_of_equip ON type_of_equip.id = equipment.type_of";
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

        private void FindAndReplace(Word.Application wordApp, object findText, object replaceText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward, ref wrap, ref format,
                ref replaceText, ref replace, ref matchKashida,
                ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }


        SaveFileDialog SaveDialog = new SaveFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            SaveDialog.InitialDirectory = "C:\\Users\\Александр\\Desktop\\";
            SaveDialog.Filter = "Microsoft Word 2007-2010 (*.docx)|*.docx";
            SaveDialog.FilterIndex = 3;
            SaveDialog.RestoreDirectory = true;
            SaveDialog.FileName = "Письмо";
            try
            {

                var query = $@"select * from respons_person where id = {comboBoxReceiver.ValueMember}";
                SqlCommand command = new SqlCommand(query, dB.getConnection());
                dB.openConnection();
                SqlDataReader reader = command.ExecuteReader();

                //Dictionary<object> Users = new Dictionary<object>();
                while (reader.Read())
                {
                    //Users.Add(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4));
                }
                reader.Close();

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            


            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // currdirect + "\\temp.docx" - путь к документу-шаблону
                    // В данном случае программа будет искать его в корне программы (папка Debug)
                    string currdirect = Application.StartupPath;
                    File.Copy(currdirect + "\\temp.docx", SaveDialog.FileName, true);
                    object missing = Missing.Value;
                    Word.Application wordApp = new Word.Application();
                    Word.Document Doc = null;
                    object filename = SaveDialog.FileName;

                    if (File.Exists((string)filename))
                    {
                        object readOnly = false;
                        object isVisible = false;
                        wordApp.Visible = false; // Выключаем видимость ворда
                        Doc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly, ref missing,
                                                      ref missing, ref missing, ref missing, ref missing,
                                                      ref missing, ref missing, ref missing, ref isVisible,
                                                      ref missing, ref missing, ref missing, ref missing);
                        Doc.Activate();
                        // Вот собственно 
                        this.FindAndReplace(wordApp, "<city>", "Воронеж");
                        this.FindAndReplace(wordApp, "<Name>", "Евгений");
                        this.FindAndReplace(wordApp, "<MyName>", "Иван");
                        this.FindAndReplace(wordApp, "<MyCity>", "Москва");
                        Doc.Save();
                    }
                    else
                        MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    wordApp.Visible = true; // И включаем видимость, это для того чтоб не видеть как там все дергается и меняется
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TranslateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.Visible = true;
            this.Visible = false;
        }

        private void comboBoxSender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxSender_SelectionChangeCommitted(object sender, EventArgs e)
        {
            respons_person obj = comboBoxSender.SelectedItem as respons_person;
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
                                    where c.id.ToString() == comboBoxSender.SelectedValue.ToString()
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
            //вызов
        }

        private void comboBoxReceiver_SelectionChangeCommitted(object sender, EventArgs e)
        {
            respons_person obj = comboBoxReceiver.SelectedItem as respons_person;
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
                                    where c.id.ToString() == comboBoxReceiver.SelectedValue.ToString()
                                    select new
                                    {
                                        Номер = u.number,
                                        Наименование = u.name_of,
                                        Тип = d.type_of,
                                        Количество = u.quantity,
                                        Цена = u.price,
                                    };
                        dataGridView2.DataSource = query.ToList();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                Cursor.Current = Cursors.Default;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /**var receeiver = comboBoxReceiver.ValueMember;
            using(MyDBEnt db = new MyDBEnt())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.equipment.Where(eq => eq.respons_pers == Convert.ToUInt16(receeiver))
                    .ExecuteUpdate(s => s
                    .SetProperty(u => u.))

            }*/
        }
    }
}
