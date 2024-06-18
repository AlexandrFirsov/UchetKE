using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UchetCT;
using UchetCT.models;

namespace WindowsFormsApp1
{
    public partial class AddForm : Form
    {
        DB db = new DB();
        Form1 form;
        public AddForm(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            nameBox.Text = "";
            quantityBox.Text = "";
            typeBox.Text = "";
            personBox.Text = "";
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            db.openConnection();

            var name = nameBox.Text;
            int quantity;
            var type = typeBox.Text;
            var person = personBox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();


            db.openConnection();

            try
            {
                if (int.TryParse(quantityBox.Text, out quantity))
                {
                    string query = $"insert into equipment(name_of, quantity, type_of, respons_pers) values('{name}', {quantity}, {type}, {person})";
                    SqlCommand sqlCommand = new SqlCommand(query, db.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись успешно создана!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Поле (Количество) должно быть целым числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            db.closeConnection();
        }

        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Visible = true;
            this.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
