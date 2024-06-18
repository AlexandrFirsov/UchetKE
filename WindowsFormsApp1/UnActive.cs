using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class UnActive : Form
    {
        public UnActive()
        {
            InitializeComponent();
        }

        private void UnActive_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            /**sing (MyDBEnt db = new MyDBEnt())
            {
                db.Configuration.ProxyCreationEnabled = false;
                comboBoxUsers.DataSource = db.respons_person.ToList();
                comboBoxUsers.ValueMember = "id";
                comboBoxUsers.DisplayMember = "lastname";

            }*/
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                using (MyDBEnt db = new MyDBEnt())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    var query = from u in db.equipment
                                join d in db.type_of_equip on u.type_of equals d.id
                                join c in db.respons_person on u.respons_pers equals c.id
                                where c.id.ToString() == comboBoxUsers.SelectedValue.ToString()
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

        private void comboBoxUsers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //respons_person obj = comboBoxUsers.SelectedItem as respons_person;
            //if (obj != null)
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
                                    where c.id.ToString() == comboBoxUsers.SelectedValue.ToString()
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
    }
}
