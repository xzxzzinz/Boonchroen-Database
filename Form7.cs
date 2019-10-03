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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database=Booncharoen; Trusted_Connection=True;"); 
        private void Form7_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                Showdata();

                dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue; //สีพื้นหลัง 
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue; //สีพื้นหลัง
                

                DataSet ds = new DataSet();
                string sql = "SELECT * FROM tblType";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "tblType");
                cbbType.DisplayMember = "TypeName";
                cbbType.ValueMember = "TypeID";
                cbbType.DataSource = ds.Tables["tblType"];
               

                DataSet ds1 = new DataSet();
                string sql1 = "SELECT * FROM tblBrand";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, conn);
                da1.Fill(ds1, "tblBrand");
                cbbBrand.DisplayMember = "BrandName";
                cbbBrand.ValueMember = "BrandID";
                cbbBrand.DataSource = ds1.Tables["tblBrand"];

                
                dataGridView1.Columns[0].HeaderCell.Value = "รหัสสินค้า";
                dataGridView1.Columns[8].HeaderCell.Value = "ประเภทสินค้า";
                dataGridView1.Columns[2].HeaderCell.Value = "ชื่อของสินค้า";
                dataGridView1.Columns[10].HeaderCell.Value = "ยี่ห้อสินค้า";
                dataGridView1.Columns[4].HeaderCell.Value = "หน่วยสินค้า";
                dataGridView1.Columns[5].HeaderCell.Value = "ราคาสินค้า";
                dataGridView1.Columns[6].HeaderCell.Value = "จำนวนสินค้า";
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns["TypeName"].DisplayIndex = 1;
                dataGridView1.Columns["BrandName"].DisplayIndex = 4;

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
            private void Showdata()
            {

                //string sql = "Select * From tblPdt";
                string sql = "SELECT * FROM tblPro INNER JOIN tblType ON tblPro.ProType = tblType.TypeId INNER JOIN tblBrand ON tblPro.ProBrand = tblBrand.BrandID WHERE TypeName LIKE '%' + '"+textBox1.Text.Trim()+"' + '%' ";

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
                txtName.Clear();
                txtUnit.Clear();
                txtPrice.Clear();
                txtEach.Clear();
            }

            private void bntAdd_Click(object sender, EventArgs e)
            {
                try
                {
                    string sql = "INSERT INTO tblPro(ProType,ProName,ProBrand,ProUnit,ProPrice,ProEach) VALUES ('"+cbbType.SelectedValue.ToString()+"', '"+txtName.Text.Trim()+"' , '"+cbbBrand.SelectedValue.ToString()+"' , '"+txtUnit.Text.Trim()+"' , '"+txtPrice.Text.Trim()+"' , '"+txtEach.Text.Trim()+"')";
                    SqlCommand com = new SqlCommand(sql, conn);
                    com.ExecuteNonQuery();

                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");

                    Showdata();
                    Cleardata();
                }
                catch
                {
                    Showdata();
                    Cleardata();
                }
            }

           
 private void btnClear_Click(object sender, EventArgs e)
            {
                Cleardata();
            }

 private void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
 {
     if (e.RowIndex == -1) { return; }

     txtID.Text =  dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
     cbbType.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
     txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
     cbbBrand.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
     txtUnit.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
     txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
     txtEach.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


 }

            private void btnUpdate_Click(object sender, EventArgs e)
            {
                string sql = "UPDATE tblPro SET ProType = '"+cbbType.SelectedValue.ToString()+"' , ProName = '"+txtName.Text.Trim()+"' , ProBrand = '"+cbbBrand.SelectedValue.ToString()+"' , ProUnit = '"+txtUnit.Text.Trim()+"' , ProPrice = '"+txtPrice.Text.Trim()+"' , ProEach = '"+txtEach.Text.Trim()+"' WHERE ProID = '"+txtID.Text.Trim()+"' ";


                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();

                MessageBox.Show("อัปเดทข้อมูลสำเร็วแล้ว");

                Showdata();
                Cleardata();
            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                if (txtID.Text.Trim() == "") { MessageBox.Show("กรุณาเลือกข้อมูลที่จะทำการลบ"); return; }

                if (MessageBox.Show("คุณต้องการลบข้อมูลใช่หรือไม่ !!!", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string sql = "DELETE FROM tblPro WHERE ProID = '"+txtID.Text.Trim()+"' ";

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
            private void Form7_FormClosing(object sender, FormClosingEventArgs e)
            {
                conn.Close();
            }

           
            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void Form7_FormClosing_1(object sender, FormClosingEventArgs e)
            {
                conn.Close();
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

    }
}
