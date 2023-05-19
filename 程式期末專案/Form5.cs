using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Diagnostics;

namespace 程式期末專案
{
    public partial class Form5 : Form
    {
        public string pustengineer;
        public string stCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database3.mdf;Integrated Security=True";
        public string stlink;
        public string sttext;
        public void show()
        {
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID,緊急度,工程師狀態,發布時間 FROM [staff] WHERE 狀態 = 'processing' AND 工程師 = '" + pustengineer + "' ORDER BY 緊急度 DESC", conn);
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sttext = richTextBox1.Text;
            richTextBox1.Text = "";
            string stresult = comboBox1.Text;
            string stengineer = comboBox2.Text;
            string sttime = DateTime.Now.ToString("d");
            string id = textBox2.Text;
            if (sttext != "")
            {
                if (comboBox1.Text != "傳送給工程師")
                {
                    SqlConnection conn = new SqlConnection(stCon);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT*FROM[staff]", conn);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    string strSQL = @"UPDATE [staff] SET 解決報告 = '" + sttext + "',解決時間 = '" + sttime + "',工程師狀態 = 'solved',狀態 = 'solved' WHERE ID = '" + id + "'";
                    cmd = new SqlCommand(strSQL, conn);
                    cmd.ExecuteNonQuery();
                    show();
                    conn.Close();
                    button4.Enabled = false;
                    textBox2.Text = "";
                    comboBox1.Text = "";
                }
                else
                {
                    SqlConnection conn = new SqlConnection(stCon);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT*FROM[staff]", conn);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    string strSQL = @"UPDATE [staff] SET 解決報告 = '" + sttext + "' ,工程師 ='" + stengineer + "' ,工程師狀態 ='" + pustengineer + "傳送給你' WHERE ID = '" + id + "'";
                    cmd = new SqlCommand(strSQL, conn);
                    cmd.ExecuteNonQuery();
                    show();
                    conn.Close();
                    button4.Enabled = false;
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
            }
            else
                MessageBox.Show("資料未輸入完全", "警告");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "傳送給工程師")
                comboBox2.Visible = true;
            else
            {
                comboBox2.Visible = false;
                button4.Enabled = true;
            }

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT 檔案 FROM[staff]  WHERE ID = '" + id + "'", conn);
            DataTable dataTableaccount = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableaccount);
            stlink = dataTableaccount.Rows[0][0].ToString();
            System.Diagnostics.Process.Start(stlink);
            show();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
        }
        

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button4.Enabled = true;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void buttonAddBUG_MouseEnter(object sender, EventArgs e)
        {
            buttonAddBUG.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void buttonAddBUG_MouseLeave(object sender, EventArgs e)
        {
            buttonAddBUG.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Dispose();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Enabled = true;
            richTextBox1.Visible = true;
            richTextBox1.Text = "";
            label1.Visible = true;
            label1.Text = "解決報告:";

        }

        private void button1_Click_1(object sender, MouseEventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
 
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string id = textBox2.Text;
            string text;
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT 敘述 FROM[staff]  WHERE ID = '" + id + "'", conn);
            DataTable dataTableaccount = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableaccount);
            text = dataTableaccount.Rows[0][0].ToString();
            richTextBox1.Enabled = true;
            richTextBox1.Visible = true;
            label1.Visible = true;
            label1.Text = "敘述:";
            richTextBox1.Text = text;
            
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
            richTextBox1.Visible = false;
            label1.Visible = false;
            richTextBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox2.Visible = false;
        }
    }
}
