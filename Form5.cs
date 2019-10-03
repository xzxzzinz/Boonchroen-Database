using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boonchroen_Database
{
    public partial class Form5 : Form
    
    {
        public Form5()
         

        {
            InitializeComponent();
        }

     

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string sql = "SELECT * FROM tblEmp WHERE EmpUsername = '" + txtUsername.Text.Trim() + "' AND EmpPassword = '" + txtPassword.Text.Trim() + "' ";
            
            SqlConnection con = new SqlConnection("Server=.\\SQLEXPRESS; Database=Booncharoen; Trusted_Connection=True;");
            SqlCommand com = new SqlCommand(sql, con);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet dt = new DataSet();
            da.Fill(dt, "tblEmp");
            string EmpLevel = dt.Tables["tblEmp"].Rows[0]["EmpLevel"].ToString();
            int Level = int.Parse(EmpLevel);
            MessageBox.Show("Login สำเร็จ");

            SqlDataReader dr = com.ExecuteReader();
           
            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }
                if (count == 1)
                {
                  
                    MessageBox.Show("Login สำเร็จ");
                    
                    if (Level == 1)
                    {
                        Form4 form = new Form4(txtUsername.Text);
                        form.Show();
                        Visible = false;
                    }
                    else
                    {
                        Form3 form = new Form3(txtUsername.Text);
                        form.Show();
                        Visible = false;
                    }
                }

                else if (count > 0)
                {
                    MessageBox.Show("กรุณากรอก username หรือ password");
                }

                else
                {
                    MessageBox.Show("username หรือ password ผิด กรุณากรอกข้อมูลใหม่");
                }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากระบบใช่หรือไม่ !!!", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

       

        
        
    }
}
