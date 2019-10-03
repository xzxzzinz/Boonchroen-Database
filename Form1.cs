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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database=Booncharoen; Trusted_Connection=True;");

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                Showdata();

                dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue; //สีพื้นหลัง 
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue; //สีพื้นหลัง
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Showdata()
        {

            string sql = "Select * From tblEmp WHERE EmpName LIKE '%' + '" + textBox1.Text.Trim() + "' + '%' ";

            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader dr = com.ExecuteReader();

            DataTable dt = new DataTable();

            if (dr.HasRows)
            {
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }

            else
            {
                dataGridView1 = null;
            }

            dr.Close();

        }

        private void Cleardata()
        {
            txtID.Clear();
            txtIDCard.Clear();
            txtName.Clear();
            txtLastName.Clear();
            txtAdd.Clear();
            txtTel.Clear();
            txtSalary.Clear();
            txtInsurance.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
               char empLevel='2';

                string sql = "INSERT INTO tblEmp (EmpIDCard,EmpName,EmpLastName,EmpAdd,EmpTel,EmpSalary,EmpInsurance,EmpUserName,EmpPassword,EmpLevel) VALUES ('" + txtIDCard.Text.Trim() + "','" + txtName.Text.Trim() + "','" + txtLastName.Text.Trim() + "','" + txtAdd.Text.Trim() + "','" + txtTel.Text.Trim() + "','" + txtSalary.Text.Trim() + "','" + txtInsurance.Text.Trim() + "','" + txtUsername.Text.Trim() + "','" + txtPassword.Text.Trim() + "','"+empLevel+"')";

                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();

                MessageBox.Show("บันทึกข้อมมูลเรียบร้อยแล้ว");

                Showdata();
                Cleardata();
            }
            catch
            {
                MessageBox.Show("ลำดับของพนักงานมีการซ้ำกัน กรุณากรอกข้อมูลใหม่");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Cleardata();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) { return; }

            txtID.Text             = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtIDCard.Text         = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text           = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtLastName.Text       = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAdd.Text            = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtTel.Text            = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtSalary.Text         = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtInsurance.Text      = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtUsername.Text       = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtPassword.Text       = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();    
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE tblEmp SET EmpIDCard='"+txtIDCard.Text.Trim()+"',EmpName='" + txtName.Text.Trim() + "',EmpLastName='" + txtLastName.Text.Trim() + "',EmpAdd='" + txtAdd.Text.Trim() + "',EmpTel='" + txtTel.Text.Trim() + "',EmpSalary='" + txtSalary.Text.Trim() + "',EmpInsurance='" + txtInsurance.Text.Trim() + "',EmpUserName='" + txtUsername.Text.Trim() + "',EmpPassword='" + txtPassword.Text.Trim() + "' WHERE EmpID='"+txtID.Text.Trim()+"' ";

            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteNonQuery();

            MessageBox.Show("อัปเดทข้อมูลสำเร็วแล้ว");

            Showdata();
            Cleardata();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == "") { MessageBox.Show("กรุณาเลือกข้อมูลที่จะทำการลบ"); return; }

            if (MessageBox.Show("คุณต้องการลบข้อมูลใช่หรือไม่ !!!", "คำยืนยัน",MessageBoxButtons.YesNo , MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
            string sql = "DELETE FROM tblEmp WHERE EmpID='" + txtID.Text.Trim() + "' ";

            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteNonQuery();

            MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว");

            Showdata();
            Cleardata();
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Showdata();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

       

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

      
     
        

       

    }
}
