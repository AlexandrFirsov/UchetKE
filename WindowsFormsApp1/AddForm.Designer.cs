namespace WindowsFormsApp1
{
    partial class AddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddForm));
            nameBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            quantityBox = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            typeBox = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            personBox = new System.Windows.Forms.TextBox();
            btn_Add = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // nameBox
            // 
            nameBox.Location = new System.Drawing.Point(133, 74);
            nameBox.Margin = new System.Windows.Forms.Padding(10);
            nameBox.Name = "nameBox";
            nameBox.Size = new System.Drawing.Size(207, 23);
            nameBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 74);
            label1.Margin = new System.Windows.Forms.Padding(10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(90, 15);
            label1.TabIndex = 1;
            label1.Text = "Наименование";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 116);
            label2.Margin = new System.Windows.Forms.Padding(10);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 15);
            label2.TabIndex = 3;
            label2.Text = "Количество";
            // 
            // quantityBox
            // 
            quantityBox.Location = new System.Drawing.Point(133, 116);
            quantityBox.Margin = new System.Windows.Forms.Padding(10);
            quantityBox.Name = "quantityBox";
            quantityBox.Size = new System.Drawing.Size(207, 23);
            quantityBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(10, 161);
            label3.Margin = new System.Windows.Forms.Padding(10);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(27, 15);
            label3.TabIndex = 5;
            label3.Text = "Тип";
            // 
            // typeBox
            // 
            typeBox.Location = new System.Drawing.Point(133, 161);
            typeBox.Margin = new System.Windows.Forms.Padding(10);
            typeBox.Name = "typeBox";
            typeBox.Size = new System.Drawing.Size(207, 23);
            typeBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(10, 204);
            label4.Margin = new System.Windows.Forms.Padding(10);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(35, 15);
            label4.TabIndex = 7;
            label4.Text = "Цена";
            // 
            // personBox
            // 
            personBox.Location = new System.Drawing.Point(133, 204);
            personBox.Margin = new System.Windows.Forms.Padding(10);
            personBox.Name = "personBox";
            personBox.Size = new System.Drawing.Size(207, 23);
            personBox.TabIndex = 6;
            // 
            // btn_Add
            // 
            btn_Add.Location = new System.Drawing.Point(4, 248);
            btn_Add.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new System.Drawing.Size(155, 56);
            btn_Add.TabIndex = 8;
            btn_Add.Text = "Добавить";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.LightGray;
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(127, 3);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(345, 58);
            panel1.TabIndex = 9;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(301, 12);
            pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(35, 35);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            label6.Location = new System.Drawing.Point(6, 31);
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
            label5.Location = new System.Drawing.Point(6, 6);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(111, 18);
            label5.TabIndex = 10;
            label5.Text = "Оборудование";
            label5.Click += label5_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(4, 3);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(115, 58);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.8403358F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.15966F));
            tableLayoutPanel1.Controls.Add(label4, 0, 4);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Controls.Add(personBox, 1, 4);
            tableLayoutPanel1.Controls.Add(typeBox, 1, 3);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(quantityBox, 1, 2);
            tableLayoutPanel1.Controls.Add(nameBox, 1, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.3773575F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.6226425F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            tableLayoutPanel1.Size = new System.Drawing.Size(476, 242);
            tableLayoutPanel1.TabIndex = 11;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(476, 358);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btn_Add);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AddForm";
            ShowIcon = false;
            Text = "Создание записи";
            FormClosed += AddForm_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox quantityBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox typeBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox personBox;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}