﻿namespace Boonchroen_Database
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public Form4(string text)
        {
            InitializeComponent();
            txtName.Text = text;
        }
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
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.Label();
            this.Hello = new System.Windows.Forms.Label();
            this.loing = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(241, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "เพิ่มสินค้าเข้าร้าน";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button3.Location = new System.Drawing.Point(56, 160);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 53);
            this.button3.TabIndex = 2;
            this.button3.Text = "ขายสินค้า";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button4.Location = new System.Drawing.Point(241, 160);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 53);
            this.button4.TabIndex = 3;
            this.button4.Text = "รายงานการขาย";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button5.Location = new System.Drawing.Point(56, 83);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(129, 53);
            this.button5.TabIndex = 4;
            this.button5.Text = "รายการสินค้า";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button6.Location = new System.Drawing.Point(145, 234);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(129, 53);
            this.button6.TabIndex = 5;
            this.button6.Text = "ข้อมูลพนักงาน";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(140, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "กรุณาเลือกรายการ";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(325, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(85, 27);
            this.button7.TabIndex = 7;
            this.button7.Text = "Logout";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtName.Location = new System.Drawing.Point(102, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(71, 24);
            this.txtName.TabIndex = 8;
            this.txtName.Text = "[Name]";
            this.txtName.Click += new System.EventHandler(this.txtName_Click);
            // 
            // Hello
            // 
            this.Hello.AutoSize = true;
            this.Hello.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Hello.Location = new System.Drawing.Point(0, 9);
            this.Hello.Name = "Hello";
            this.Hello.Size = new System.Drawing.Size(96, 24);
            this.Hello.TabIndex = 9;
            this.Hello.Text = "ยินดีต้อนรับ";
            this.Hello.Click += new System.EventHandler(this.Hello_Click);
            // 
            // loing
            // 
            this.loing.AutoSize = true;
            this.loing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.loing.Location = new System.Drawing.Point(179, 9);
            this.loing.Name = "loing";
            this.loing.Size = new System.Drawing.Size(81, 24);
            this.loing.TabIndex = 10;
            this.loing.Text = "เข้าสู่ระบบ";
            this.loing.Click += new System.EventHandler(this.loing_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 311);
            this.Controls.Add(this.loing);
            this.Controls.Add(this.Hello);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Name = "Form4";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label Hello;
        private System.Windows.Forms.Label loing;
    }
}