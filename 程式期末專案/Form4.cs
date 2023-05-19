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
    public partial class Form4 : Form
    {
        public string puname;
        public string stCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database3.mdf;Integrated Security=True";
        public string stlink;
        public void show()
        {
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID,發布者姓名,緊急度,發布時間 FROM [staff] WHERE 狀態 = 'waiting' ORDER BY 緊急度 DESC", conn); 
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;
            string sttime = DateTime.Now.ToString("d");
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM[staff]", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            string strSQL = @"UPDATE [staff] SET 狀態 = 'nobug',檔案 = '"+ stlink + "',解決時間 = '"+sttime+ "' WHERE ID = '" + id + "'";
            cmd = new SqlCommand(strSQL, conn);
            cmd.ExecuteNonQuery();
            show();
            conn.Close();
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;
            string stengineer = comboBox1.Text;
            if (stengineer != "")
            {
                SqlConnection conn = new SqlConnection(stCon);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT*FROM[staff]", conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                string strSQL = @"UPDATE [staff] SET 狀態 = 'processing' WHERE ID = '" + id + "'";
                cmd = new SqlCommand(strSQL, conn);
                cmd.ExecuteNonQuery();
                strSQL = @"UPDATE [staff] SET 工程師 = '" + stengineer + "' WHERE ID = '" + id + "'";
                cmd = new SqlCommand(strSQL, conn);
                cmd.ExecuteNonQuery();
                strSQL = @"UPDATE [staff] SET 工程師狀態 = 'unsolved' WHERE ID = '" + id + "'";
                cmd = new SqlCommand(strSQL, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                textBox2.Text = "";
                comboBox1.Text = "";
                button5.Enabled = false;
                show();
            }
            else
                MessageBox.Show("資料未輸入完全", "警告");
        }

        private void button3_Click(object sender, EventArgs e)
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
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button5.Enabled = true;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void buttonAddBUG_MouseEnter(object sender, EventArgs e)
        {
            buttonAddBUG.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void buttonAddBUG_MouseLeave(object sender, EventArgs e)
        {
            buttonAddBUG.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
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
            richTextBox1.Text = text;
            label1.Visible = true;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
            richTextBox1.Text = "";
            richTextBox1.Enabled = false;
            richTextBox1.Visible = false;
            comboBox1.Text = "";
            
        }
    }
}

