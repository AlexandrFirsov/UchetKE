namespace WindowsFormsApp1
{
    partial class AddUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUsers));
            panel1 = new System.Windows.Forms.Panel();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            labelPostUser = new System.Windows.Forms.Label();
            textBoxPost = new System.Windows.Forms.TextBox();
            labelLastNameUser = new System.Windows.Forms.Label();
            textBoxSurname = new System.Windows.Forms.TextBox();
            labelSurnameUser = new System.Windows.Forms.Label();
            textBoxLastName = new System.Windows.Forms.TextBox();
            labelNameUser = new System.Windows.Forms.Label();
            textBoxName = new System.Windows.Forms.TextBox();
            btn_Add = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Location = new System.Drawing.Point(87, 3);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(390, 54);
            panel1.TabIndex = 10;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(338, 12);
            pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(35, 35);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            label6.Location = new System.Drawing.Point(20, 28);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(122, 16);
            label6.TabIndex = 11;
            label6.Text = "Создание записи";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            label5.Location = new System.Drawing.Point(20, 7);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(110, 18);
            label5.TabIndex = 10;
            label5.Text = "Пользователи";
            label5.Click += label5_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(4, 3);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(56, 54);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // labelPostUser
            // 
            labelPostUser.AutoSize = true;
            labelPostUser.Location = new System.Drawing.Point(10, 185);
            labelPostUser.Margin = new System.Windows.Forms.Padding(10);
            labelPostUser.Name = "labelPostUser";
            labelPostUser.Size = new System.Drawing.Size(63, 19);
            labelPostUser.TabIndex = 11;
            labelPostUser.Text = "Должность";
            // 
            // textBoxPost
            // 
            textBoxPost.Location = new System.Drawing.Point(93, 185);
            textBoxPost.Margin = new System.Windows.Forms.Padding(10);
            textBoxPost.Name = "textBoxPost";
            textBoxPost.Size = new System.Drawing.Size(192, 23);
            textBoxPost.TabIndex = 10;
            // 
            // labelLastNameUser
            // 
            labelLastNameUser.AutoSize = true;
            labelLastNameUser.Location = new System.Drawing.Point(10, 147);
            labelLastNameUser.Margin = new System.Windows.Forms.Padding(10);
            labelLastNameUser.Name = "labelLastNameUser";
            labelLastNameUser.Size = new System.Drawing.Size(58, 15);
            labelLastNameUser.TabIndex = 5;
            labelLastNameUser.Text = "Отчество";
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new System.Drawing.Point(93, 147);
            textBoxSurname.Margin = new System.Windows.Forms.Padding(10);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new System.Drawing.Size(192, 23);
            textBoxSurname.TabIndex = 4;
            textBoxSurname.TextChanged += textBoxSurname_TextChanged;
            // 
            // labelSurnameUser
            // 
            labelSurnameUser.AutoSize = true;
            labelSurnameUser.Location = new System.Drawing.Point(10, 107);
            labelSurnameUser.Margin = new System.Windows.Forms.Padding(10);
            labelSurnameUser.Name = "labelSurnameUser";
            labelSurnameUser.Size = new System.Drawing.Size(58, 15);
            labelSurnameUser.TabIndex = 3;
            labelSurnameUser.Text = "Фамилия";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new System.Drawing.Point(93, 107);
            textBoxLastName.Margin = new System.Windows.Forms.Padding(10);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new System.Drawing.Size(192, 23);
            textBoxLastName.TabIndex = 2;
            // 
            // labelNameUser
            // 
            labelNameUser.AutoSize = true;
            labelNameUser.Location = new System.Drawing.Point(10, 70);
            labelNameUser.Margin = new System.Windows.Forms.Padding(10);
            labelNameUser.Name = "labelNameUser";
            labelNameUser.Size = new System.Drawing.Size(31, 15);
            labelNameUser.TabIndex = 1;
            labelNameUser.Text = "Имя";
            // 
            // textBoxName
            // 
            textBoxName.Location = new System.Drawing.Point(93, 70);
            textBoxName.Margin = new System.Windows.Forms.Padding(10);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new System.Drawing.Size(192, 23);
            textBoxName.TabIndex = 0;
            // 
            // btn_Add
            // 
            btn_Add.Location = new System.Drawing.Point(7, 223);
            btn_Add.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new System.Drawing.Size(131, 40);
            btn_Add.TabIndex = 12;
            btn_Add.Text = "Добавить";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click_1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.1735249F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.82648F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Controls.Add(labelPostUser, 0, 4);
            tableLayoutPanel1.Controls.Add(textBoxPost, 1, 4);
            tableLayoutPanel1.Controls.Add(labelSurnameUser, 0, 2);
            tableLayoutPanel1.Controls.Add(textBoxSurname, 1, 3);
            tableLayoutPanel1.Controls.Add(labelLastNameUser, 0, 3);
            tableLayoutPanel1.Controls.Add(labelNameUser, 0, 1);
            tableLayoutPanel1.Controls.Add(textBoxLastName, 1, 2);
            tableLayoutPanel1.Controls.Add(textBoxName, 1, 1);
            tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.85567F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.14433F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            tableLayoutPanel1.Size = new System.Drawing.Size(485, 214);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // AddUsers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(496, 358);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btn_Add);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AddUsers";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Добавление пользователя";
            FormClosed += AddUsers_FormClosed;
            Load += AddUsers_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelPostUser;
        private System.Windows.Forms.TextBox textBoxPost;
        private System.Windows.Forms.Label labelLastNameUser;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.Label labelSurnameUser;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelNameUser;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}