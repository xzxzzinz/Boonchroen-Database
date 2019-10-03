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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection ("Server=.\\SQLEXPRESS; Database=Booncharoen; Trusted_Connection=True;");
        private void Form9_Load(object sender, EventArgs e)
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

                txtDate.Text = DateTime.Now.ToLongDateString();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        double  vat , no = 0 , final , to ; //ประกาศตัวแปรให้เป็นPrivate ตัวแปรราคาสินคา,รายการสินค้า,ภาษี,หักภาษี,ส่วนลด,สุทธิ

        private void Showdata()
        {
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

       
       

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex == -1) { return; }


            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbbType.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbbBrand.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtUnit.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtEach.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(txtID.Text);
            listBox2.Items.Add(cbbType.SelectedValue.ToString());
            listBox3.Items.Add(txtName.Text);
            listBox4.Items.Add(cbbBrand.SelectedValue.ToString());
            listBox5.Items.Add(txtUnit.Text);
            listBox6.Items.Add(txtEach.Text);
            listBox7.Items.Add(label4.Text);
            listBox8.Items.Add(vat);
           

            no += 1;
            label12.Text = no.ToString();

            button4_Click(sender, e);
            final = to;
            label16.Text = final.ToString("#,###");


           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string price = txtPrice.Text;
            string each = txtEach.Text;
            double total;

            //string Number = " 200"; // 200 ในชนิดของ string ไม่สามารถนำไปคำนวณได้
            int ConvertNum = int.Parse(price);
            int Converteach = int.Parse(each);

            total = ConvertNum * Converteach;
            vat = total * 7 / 100; //หาค่าภาษี
            label4.Text = total.ToString("#,###");

        }

        private void txtEach_TextChanged(object sender, EventArgs e)
        {

            string price = txtPrice.Text;
            string each = txtEach.Text;
            string num = textBox1.Text;
            double total;

            int ConvertNum = int.Parse(price);
            int Converteach = int.Parse(each);
            int ConvertN = int.Parse(num);

            if (Converteach <= ConvertN)
            {
                total = ConvertNum * Converteach;
                vat = total * 7 / 100;
                label4.Text = total.ToString("#,###");
            }
            else
            {
                MessageBox.Show("เกินจำนวนสินค้าในสต๊อก" , "ยืนยันสินค้าเกินจำนวน" , MessageBoxButtons.OK, MessageBoxIcon.Stop );
                txtEach.Text = num;
            }

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double money = 0, sum = 0, money1 = 0, sum1 = 0;
            int round, a, round1, a1;

            round = listBox7.Items.Count;
            round1 = listBox8.Items.Count;

            for (a = 0; a < round; a++)
            {
                money = double.Parse(listBox7.Items[a].ToString());
                sum += money; 
            }

            for (a1 = 0; a1 < round1; a1++)
            {
                money1 = double.Parse(listBox8.Items[a1].ToString());
                sum1 += money1;
            }
            to = sum + sum1;
            label14.Text = to.ToString("#,###");
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO tblSell (SellDate,EmpID,SellSum) VALUES ('"+txtDate.Text.Trim()+"' , '"+NameSell.Text.Trim()+"' , '"+label16.Text+"') ";
            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteNonQuery();

            string sql1 = "SELECT MAX(tblSell.SellID) as a from tblSell";

            SqlDataAdapter da = new SqlDataAdapter(sql1,conn);
            
            DataSet dt = new DataSet();
            da.Fill(dt, "tblSell");
           
            string Max = Convert.ToString(dt.Tables["tblSell"].Rows[0]["a"].ToString());
            
            txtMax1.Text = Max;

       

            for (int i = 0; i < listBox1.Items.Count; i++)
            {

                string sql3 = "INSERT INTO tblListSell (ProID,ProPrice,ProEach,SellID) VALUES ('"+listBox1.Items[i].ToString()+"' , '"+listBox7.Items[i].ToString()+"' , '"+listBox6.Items[i].ToString()+"' , '"+txtMax1.Text+"')";
                SqlCommand com3 = new SqlCommand(sql3, conn);
                com3.ExecuteNonQuery();


                string sql4 = "SELECT ProEach From tblPro WHERE ProID = '"+listBox1.Items[i].ToString()+"'";
                SqlDataAdapter da1 = new SqlDataAdapter(sql4, conn);
                DataSet dt1 = new DataSet();
                da1.Fill (dt1, "tblPro");
                string each = Convert.ToString(dt1.Tables["tblPro"].Rows[0]["ProEach"].ToString()); 
                string ea = listBox6.Items[i].ToString();
                
                int eac  = int.Parse(ea);
                int eamax = int.Parse(each);
                int stock;

                stock = eamax - eac;
                string st = Convert.ToString(stock);

                string sql7 = "UPDATE tblPro SET ProEach = '"+st+"' WHERE ProID = '"+listBox1.Items[i].ToString()+"'";
                SqlCommand com7 = new SqlCommand(sql7, conn);
                com7.ExecuteNonQuery();

                Showdata();
                

                
            }

            listBox1.Items.Clear();

           





                MessageBox.Show("ขายสินค้าเรียบร้อยแล้ว");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Showdata();
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
