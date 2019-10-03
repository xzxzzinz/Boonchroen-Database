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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database=Booncharoen; Trusted_Connection=True;"); 
        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                Showdata();
                ShowdataPdt();

                
                dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue; //สีพื้นหลัง 
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue; //สีพื้นหลัง

                dataGridView2.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue; //สีพื้นหลัง 
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue; //สีพื้นหลัง
               
                DataSet ds = new DataSet();
                string sql = "SELECT * FROM tblType";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "TypeID");
                cbbType.DisplayMember = "TypeID";
                cbbType.ValueMember = "TypeName";
                cbbType.DataSource = ds.Tables["TypeID"];

                DataSet ds1 = new DataSet();
                string sql1 = "SELECT * FROM tblBrand";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, conn);
                da1.Fill(ds1, "BrandID");
                cbbBrand.DisplayMember = "BrandID";
                cbbBrand.ValueMember = "BrandName";
                cbbBrand.DataSource = ds1.Tables["BrandID"];

                DataSet ds2 = new DataSet();
                string sql2 = "SELECT * FROM tblType";
                SqlDataAdapter da2 = new SqlDataAdapter(sql2, conn);
                da2.Fill(ds2, "TypeID");
                cbbType1.DisplayMember = "TypeID";
                cbbType1.ValueMember = "TypeName";
                cbbType1.DataSource = ds2.Tables["TypeID"];

                DataSet ds3 = new DataSet();
                string sql3 = "SELECT * FROM tblBrand";
                SqlDataAdapter da3 = new SqlDataAdapter(sql3, conn);
                da3.Fill(ds3, "BrandID");
                cbbBrand1.DisplayMember = "BrandID";
                cbbBrand1.ValueMember = "BrandName";
                cbbBrand1.DataSource = ds3.Tables["BrandID"];
                
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Showdata()
        {
            
            //string sql = "Select * From tblAdd WHERE AddType LIKE '%' + '" + textBox1.Text.Trim() + "' + '%' ";
            string sql = "SELECT * FROM tblAdd INNER JOIN tblType ON tblAdd.AddType = tblType.TypeId INNER JOIN tblBrand ON tblAdd.AddBrand = tblBrand.BrandID";
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

        private void ShowdataPdt()
        {

            //string sql = "Select * From tblAdd WHERE AddType LIKE '%' + '" + textBox1.Text.Trim() + "' + '%' ";
            string sql = "SELECT * FROM tblPro INNER JOIN tblType ON tblPro.ProType = tblType.TypeId INNER JOIN tblBrand ON tblPro.ProBrand = tblBrand.BrandID";
            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader dr = com.ExecuteReader();

            DataTable dt = new DataTable();

            if (dr.HasRows)
            {
                dt.Load(dr);
                dataGridView2.DataSource = dt;
            }

            else
            {
                dataGridView2 = null;
            }

            dr.Close();
        }

        private void Cleardata()
        {
            txtID.Clear();
            txtName.Clear();
            txtUnit.Clear();
            txtPrice.Clear();
            txtEach.Clear();
            txtCompany.Clear();
            txtDate.Clear();
            txtInvioce.Clear();
            txtDiscoust.Clear();
            txtNote.Clear();
        }
        
        private void CleardataPdt()
        {
            txtID1.Clear();
            txtName1.Clear();
            txtUnit1.Clear();
            txtPrice1.Clear();
            txtEach1.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {


                string sql = "INSERT INTO tblAdd (AddID,AddType,AddName,AddBrand,AddUnit,AddPrice,AddEach,AddCompany,AddDate,AddInvioce,AddDiscoust,AddNote,ProID) VALUES ('" + txtID.Text.Trim() + "','" + cbbType.Text +"','" + txtName.Text.Trim() + "','" + cbbBrand.Text + "','" + txtUnit.Text.Trim() + "','" + txtPrice.Text.Trim() + "','" + txtEach.Text.Trim() + "','" + txtCompany.Text.Trim() + "','" + txtDate.Text.Trim() + "','" + txtInvioce.Text.Trim() + "','" + txtDiscoust.Text.Trim() + "','" + txtNote.Text.Trim() + "' , '"+txtID1.Text.Trim()+"')";

                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();

                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");

                Showdata();
                 
            }
            catch
            {
                MessageBox.Show("รหัสซ้ำ");
            }
        }
        
        private void bntAdd1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO tblAdd(AddID,AddType,AddName,ProBrand,ProUnit,ProPrice,ProEach) VALUES ('" + txtID1.Text.Trim() + "' , '" + cbbType1.Text + "', '" + txtName1.Text.Trim() + "' , '" + cbbBrand1.Text + "' , '" + txtUnit1.Text.Trim() + "' , '" + txtPrice1.Text.Trim() + "' , '" + txtEach1.Text.Trim() + "')";
                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();

                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");

                ShowdataPdt();
                CleardataPdt();
            }
            catch
            {
                MessageBox.Show("รหัสซ้ำ");
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Cleardata();

        }
        private void btnClear1_Click(object sender, EventArgs e)
        {
            CleardataPdt();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex == -1) { return;}

            txtID.Text          = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbbType.Text        = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text        = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbbBrand.Text       = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtUnit.Text        = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPrice.Text       = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEach.Text        = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtCompany.Text     = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDate.Text        = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtInvioce.Text     = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtDiscoust.Text    = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtNote.Text        = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
        }
       
        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex == -1) { return; }

            txtID1.Text         = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbbType1.Text       = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName1.Text       = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbbBrand1.Text      = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtUnit1.Text       = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPrice1.Text      = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEach1.Text       = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE tblAdd SET AddID='" + txtID.Text.Trim() + "' , AddType='" + cbbType.Text + "', AddName='" + txtName.Text.Trim() + "', AddBrand='" + cbbBrand.Text + "', AddUnit='" + txtUnit.Text.Trim() + "', AddPrice='" + txtPrice.Text.Trim() + "', AddEach='" + txtEach.Text.Trim() + "', AddCompany='" + txtCompany.Text.Trim() + "', AddDate='" + txtDate.Text.Trim() + "', AddInvioce='" + txtInvioce.Text.Trim() + "', AddDiscoust='" + txtDiscoust.Text.Trim() + "', AddNote='" + txtNote.Text.Trim() + "'WHERE AddID='" + txtID.Text.Trim() + "'";

            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteNonQuery();

            MessageBox.Show("อัปเดทข้อมูลสำเร็วแล้ว");

            Showdata();
            Cleardata();
        }
        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE tblPro SET ProID = '" + txtID1.Text.Trim() + "' , PrpType = '" + cbbType1.Text + "' , ProName = '" + txtName1.Text.Trim() + "' , ProBrand = '" + cbbBrand1.Text + "' , ProUnit = '" + txtUnit1.Text.Trim() + "' , ProPrice = '" + txtPrice1.Text.Trim() + "' , ProEach = '" + txtEach1.Text.Trim() + "' WHERE ProID = '" + txtID.Text.Trim() + "' ";

            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteNonQuery();

            MessageBox.Show("อัปเดทข้อมูลสำเร็วแล้ว");

            ShowdataPdt();
            CleardataPdt();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == "") { MessageBox.Show("กรุณาเลือกข้อมูลที่จะทำการลบ"); return; }

            if (MessageBox.Show("คุณต้องการลบข้อมูลใช่หรือไม่ !!!", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string sql = "DELETE FROM tblAdd WHERE AddID='" + txtID.Text.Trim() + "' ";

                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();

                MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว");

                Showdata();
                Cleardata();
            }
        }
        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (txtID1.Text.Trim() == "") { MessageBox.Show("กรุณาเลือกข้อมูลที่จะทำการลบ"); return; }

            if (MessageBox.Show("คุณต้องการลบข้อมูลใช่หรือไม่ !!!", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string sql = "DELETE FROM tblPro WHERE ProID='" + txtID1.Text.Trim() + "' ";

                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();

                MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว");

                ShowdataPdt();
                CleardataPdt();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Showdata();
        }
        private void btnSearch1_Click(object sender, EventArgs e)
        {
            ShowdataPdt();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
            Visible = false;
        }

        private void txtPrice1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtEach1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtEach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        
   }
}
