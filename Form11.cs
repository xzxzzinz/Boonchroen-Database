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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=Booncharoen; Trusted_Connection=True;");
        private void Form11_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                ShowdataListSell();
                

                
                dataGridView2.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue; //สีพื้นหลัง 
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue; //สีพื้นหลัง



                dataGridView2.Columns[0].HeaderCell.Value = "รหัสรายการสินค้าขาย";
                dataGridView2.Columns[2].HeaderCell.Value = "ราคารวมของสินค้า";
                dataGridView2.Columns[3].HeaderCell.Value = "ขายจำนวน";
                dataGridView2.Columns[4].HeaderCell.Value = "รหัสการขาย";
                dataGridView2.Columns[7].HeaderCell.Value = "ชื่อสินค้าที่ขาย";
                dataGridView2.Columns[13].HeaderCell.Value = "ประเภทสินค้าที่ขาย";
                dataGridView2.Columns[15].HeaderCell.Value = "ยี่ห้อสินค้าที่ขาย";
                dataGridView2.Columns[17].HeaderCell.Value = "วันที่ขายสินค้า";
                dataGridView2.Columns[18].HeaderCell.Value = "พนักงงานขาย";
                dataGridView2.Columns[19].HeaderCell.Value = "ราคารวม";
                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[5].Visible = false;
                dataGridView2.Columns[6].Visible = false;
                dataGridView2.Columns[8].Visible = false;
                dataGridView2.Columns[9].Visible = false;
                dataGridView2.Columns[10].Visible = false;
                dataGridView2.Columns[11].Visible = false;
                dataGridView2.Columns[12].Visible = false;
                dataGridView2.Columns[14].Visible = false;
                dataGridView2.Columns[16].Visible = false;
                dataGridView2.Columns["TypeName"].DisplayIndex = 1;
                dataGridView2.Columns["ProName"].DisplayIndex = 2;
                dataGridView2.Columns["BrandName"].DisplayIndex = 3;
              

                


              
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

     
        private void ShowdataListSell()
        {
            string sql = "SELECT * FROM tblListSell INNER JOIN tblPro ON tblListSell.ProID = tblPro.ProID INNER JOIN tblType ON tblPro.ProType = tblType.TypeID INNER JOIN tblBrand ON tblPro.ProBrand = tblBrand.BrandID INNER JOIN tblSell ON tblListSell.SellID = tblSell.SellID WHERE TypeName LIKE '%' + '" + textBox1.Text.Trim() + "' + '%'";
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowdataListSell();
        }

       
        }
        
    }

