using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boonchroen_Database
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void txtName_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7(txtName.Text);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 form = new Form9(txtName.Text);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8(txtName.Text);
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form11 form = new Form11(txtName.Text);
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากระบบใช่หรือไม่?", "ยืนยันการออกจากระบบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Form5 form = new Form5();
                form.Show();
                Visible = false;

            }
        }





        
    }
}
