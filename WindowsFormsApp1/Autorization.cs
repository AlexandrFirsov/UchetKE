using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UchetCT.models;

namespace UchetCT
{
    public partial class AutorizationForm : Form
    {
        DB MyDB = new DB();
        public AutorizationForm()
        {
            InitializeComponent();
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            var loginuser = LoginBox.Text;
            var passworduser = PasswordBox.Text;


            string SQLQuery = $"select login_user, password_user from respons_person where login_user = '{loginuser}' and password_user = '{passworduser}'";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();

                SqlCommand sqlCommand = new SqlCommand(SQLQuery, MyDB.getConnection());

                adapter.SelectCommand = sqlCommand;
                adapter.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    Form1 form1 = new Form1(this);
                    form1.Show();
                    this.Hide();
                }


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void AutorizationForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            PasswordBox.PasswordChar = '*';

        }
    }
}
