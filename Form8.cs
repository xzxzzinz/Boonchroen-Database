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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
       
        SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database=Booncharoen; Trusted_Connection=True;");
        private void Form8_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                Showdata();
                ShowdataAdd();
                

                dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue; //สีพื้นหลัง 
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue; //สีพื้นหลัง

                dataGridView2.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue; //สีพื้นหลัง 
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue; //สีพื้นหลัง

               

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

                DataSet ds2 = new DataSet();
                string sql2 = "SELECT * FROM tblType";
                SqlDataAdapter da2 = new SqlDataAdapter(sql2, conn);
                da2.Fill(ds2, "tblType");
                cbbType1.DisplayMember = "TypeName";
                cbbType1.ValueMember = "TypeID";
                cbbType1.DataSource = ds2.Tables["tblType"];

                DataSet ds3 = new DataSet();
                string sql3 = "SELECT * FROM tblBrand";
                SqlDataAdapter da3 = new SqlDataAdapter(sql3, conn);
                da3.Fill(ds3, "tblBrand");
                cbbBrand1.DisplayMember = "BrandName";
                cbbBrand1.ValueMember = "BrandID";
                cbbBrand1.DataSource = ds3.Tables["tblBrand"];

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

                dataGridView2.Columns[0].HeaderCell.Value = "รหัสสินค้า";
                dataGridView2.Columns[14].HeaderCell.Value = "ประเภทสินค้า";
                dataGridView2.Columns[16].HeaderCell.Value = "ยี่ห้อสินค้า";
                dataGridView2.Columns[2].HeaderCell.Value = "ชื่อของสินค้า";
                dataGridView2.Columns[4].HeaderCell.Value = "หน่วยสินค้า";
                dataGridView2.Columns[5].HeaderCell.Value = "ราคาสินค้า";
                dataGridView2.Columns[6].HeaderCell.Value = "จำนวนสินค้า";
                dataGridView2.Columns[7].HeaderCell.Value = "ผู้ส่ง";
                dataGridView2.Columns[8].HeaderCell.Value = "วันที่ซื้อ";
                dataGridView2.Columns[9].HeaderCell.Value = "หมายเลขบิล";
                dataGridView2.Columns[10].HeaderCell.Value = "ส่วนลด";
                dataGridView2.Columns[11].HeaderCell.Value = "หมายเหตุ";
                dataGridView2.Columns[12].Visible = false;
                dataGridView2.Columns[13].Visible = false;
                dataGridView2.Columns[15].Visible = false;
                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[3].Visible = false;
                dataGridView2.Columns["TypeName"].DisplayIndex = 1;
                dataGridView2.Columns["BrandName"].DisplayIndex = 4;
                


            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
        private void Showdata()
        {

            //string sql = "Select * From tblPro";
            string sql = "SELECT * FROM tblPro INNER JOIN tblType ON tblPro.ProType = tblType.TypeId INNER JOIN tblBrand ON tblPro.ProBrand = tblBrand.BrandID WHERE TypeName LIKE '%' + '"+txtSearch.Text.Trim()+"' + '%' ";

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
        
        private void ShowdataAdd()
        {

            //string sql = "Select * From tblPro";
            string sql = "SELECT * FROM tblAdd INNER JOIN tblType ON tblAdd.AddType = tblType.TypeId INNER JOIN tblBrand ON tblAdd.AddBrand = tblBrand.BrandID WHERE TypeName LIKE '%' + '"+textBox1.Text.Trim()+"' + '%' ";

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
            cbbBrand.ResetText();
            txtName.Clear();
            cbbType.ResetText();
            txtUnit.Clear();
            txtPrice.Clear();
            txtEach.Clear();
            txtEach3.Clear();
            txtCompany.Clear();
            txtDate.Clear();
            txtInvioce.Clear();
            txtDiscoust.Clear();
            txtNote.Clear();
        }

        private void CleardataAdd()
        {
            txtID1.Clear();
            cbbType1.ResetText();
            txtName1.Clear();
            cbbBrand1.ResetText();
            txtUnit1.Clear();
            txtPrice1.Clear();
            txtEach1.Clear();
            txtCompany1.Clear();
            txtDate1.Clear();
            txtInvioce1.Clear();
            txtDiscoust1.Clear();
            txtNote1.Clear();
            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO tblAdd(AddType,AddName,AddBrand,AddUnit,AddPrice,AddEach,AddCompany,AddDate,AddInvioce,AddDiscoust,AddNote,ProID) VALUES  ('" + cbbType.SelectedValue.ToString() + "' , '" + txtName.Text.Trim() + "' , '" + cbbBrand.SelectedValue.ToString() + "' , '" + txtUnit.Text.Trim() + "' , '" + txtPrice.Text.Trim() + "' , '" + txtEach.Text.Trim() + "' , '"+txtCompany.Text.Trim()+"' , '"+txtDate.Text.Trim()+"' , '"+txtInvioce.Text.Trim()+"' , '"+txtDiscoust.Text.Trim()+"' , '"+txtNote.Text.Trim()+"' , '"+txtID.Text.Trim()+"')";
                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();

                string each = txtEach.Text;
                string each1 = txtEach3.Text;
                int ee = int.Parse(each);
                int e1 = int.Parse(each1);
                int sumeach;

                sumeach = ee + e1;
                string sume = Convert.ToString(sumeach);
                txtSumEach.Text = sume;

                string sql1 = "UPDATE tblPro SET ProEach = '" + txtSumEach.Text.Trim() + "' WHERE ProID = '" + txtID.Text.Trim() + "' ";
                SqlCommand com1 = new SqlCommand(sql1, conn);
                com1.ExecuteNonQuery();


                
                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");

                Showdata();
                ShowdataAdd();
                Cleardata();
            }
            catch
            {
                MessageBox.Show("รหัสซ้ำ");
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO tblAdd(AddType,AddName,AddBrand,AddUnit,AddPrice,AddEach,AddCompany,AddDate,AddInvioce,AddDiscoust,AddNote) VALUES  ('"+cbbType1.SelectedValue.ToString()+"' , '"+txtName1.Text.Trim()+"' , '"+cbbBrand1.SelectedValue.ToString()+"' , '"+txtUnit1.Text.Trim()+"' , '"+txtPrice1.Text.Trim()+"' , '"+txtEach1.Text.Trim()+"' , '"+txtCompany1.Text.Trim()+"' , '"+txtDate1.Text.Trim()+"' , '"+txtInvioce1.Text.Trim()+"' , '"+txtDiscoust1.Text.Trim()+"' , '"+txtNote1.Text.Trim()+"')";
                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();
                
                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");

                ShowdataAdd();
                CleardataAdd();
                
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
            CleardataAdd();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) { return; }

            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbbType.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbbBrand.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtUnit.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEach.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtEach3.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) { return; }

            txtID1.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbbType1.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName1.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbbBrand1.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtUnit1.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPrice1.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEach1.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtCompany1.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDate1.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtInvioce1.Text = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtDiscoust1.Text = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtNote1.Text = dataGridView2.Rows[e.RowIndex].Cells[11].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE tblAdd SET AddType = '" + cbbType1.SelectedValue.ToString() + "' , AddName = '" + txtName1.Text.Trim() + "' , AddBrand = '" + cbbBrand1.SelectedValue.ToString() + "' , AddUnit = '" + txtUnit1.Text.Trim() + "' , AddPrice = '" + txtPrice1.Text.Trim() + "' , AddEach = '" + txtEach1.Text.Trim() + "' , AddCompany = '" + txtCompany1.Text.Trim() + "' , AddDate = '" + txtDate1.Text.Trim() + "' , AddInvioce = '" + txtInvioce1.Text.Trim() + "' , AddDiscoust = '" + txtDiscoust1.Text.Trim() + "' , AddNote = '" + txtNote1.Text.Trim() + "' WHERE AddID = '"+txtID1.Text.Trim()+"' ";


            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteNonQuery();

            MessageBox.Show("อัปเดทข้อมูลสำเร็วแล้ว");
            ShowdataAdd();
            Cleardata();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID1.Text.Trim() == "") { MessageBox.Show("กรุณาเลือกข้อมูลที่จะทำการลบ"); return; }
            if (MessageBox.Show("คุณต้องการลบข้อมูลใช่หรือไม่ !!!", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string sql = "DELETE FROM tblAdd WHERE AddID='" + txtID1.Text.Trim() + "' ";

                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();

                MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว");

                ShowdataAdd();
                CleardataAdd();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Showdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowdataAdd();
        }

    

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
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

      

       
      


    }
}
