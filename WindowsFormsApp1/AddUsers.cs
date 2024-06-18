using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UchetCT;
using UchetCT.models;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class AddUsers : Form
    {
        DB dB = new DB();
        Form1 form1;
        public AddUsers(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            textBoxLastName.Text = "";
            textBoxSurname.Text = "";
            textBoxPost.Text = "";
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AddUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
            form1.Visible = true;
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void AddUsers_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click_1(object sender, EventArgs e)
        {
            dB.openConnection();

            var name = textBoxName.Text;
            var lastname = textBoxLastName.Text;
            var surname = textBoxSurname.Text;
            var post = textBoxPost.Text;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                string query = $"insert into respons_person(_name, lastname, surname, post) values('{name}', '{lastname}', '{surname}', '{post}')";
                SqlCommand sqlCommand = new SqlCommand(query, dB.getConnection());
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dB.closeConnection();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

            var helper = new WordHelper("МБОУ_принятие_сотрудника.docx");

            var Adduser = new Dictionary<string, string>
            {
                { $"<{labelNameUser.Text}>", textBoxName.Text },
                { $"<{labelSurnameUser.Text}>", textBoxLastName.Text },
                { $"<{labelLastNameUser.Text}>", textBoxSurname.Text },
                { $"<{labelPostUser.Text}>", textBoxPost.Text },
            };
            helper.Process(Adduser);
        }
    }
}
