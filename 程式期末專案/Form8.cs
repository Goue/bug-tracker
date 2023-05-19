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
    public partial class Form8 : Form
    {
        public string stCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database3.mdf;Integrated Security=True";
        public string id;
        public void Endshow()
        {
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID,緊急度,狀態,發布者姓名,發布時間,工程師,解決時間 FROM [staff] WHERE 狀態 = 'end' ORDER BY ID", conn);
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }
        public void Noendshow()
        {
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID,緊急度,狀態,發布時間 FROM [staff] WHERE Not 狀態 = 'END' ORDER BY ID", conn);
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }
        public void show()
        {
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID,緊急度,狀態 FROM [staff] ORDER BY ID", conn);
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }
        public Form8()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Dispose();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            id = textBox2.Text;
            string a;
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT 狀態 FROM[staff]  WHERE ID = '" + id + "'", conn);
            DataTable dataTableaccount = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableaccount);
            a = dataTableaccount.Rows[0][0].ToString();
            if(a == "waiting")
            {
                conn = new SqlConnection(stCon);
                conn.Open();
                cmd = new SqlCommand("SELECT id,緊急度,狀態,發布者姓名,發布時間 FROM [staff] WHERE ID = '" + id + "'", conn);
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                button4.Enabled = false;
                button4.Visible = false;
            }
            else if(a== "processing")
            {
                conn = new SqlConnection(stCon);
                conn.Open();
                cmd = new SqlCommand("SELECT ID,緊急度,狀態,發布者姓名,發布時間 FROM [staff] WHERE ID = '" + id + "'", conn);
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                button4.Enabled = false;
                button4.Visible = false;
            }
            else if(a == "nobug")
            {
                conn = new SqlConnection(stCon);
                conn.Open();
                cmd = new SqlCommand("SELECT ID,緊急度,狀態,發布者姓名,發布時間,解決時間 FROM [staff] WHERE ID = '" + id + "'", conn);
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                button4.Enabled = false;
                button4.Visible = false;
            }
            else
            {
                conn = new SqlConnection(stCon);
                conn.Open();
                cmd = new SqlCommand("SELECT ID,緊急度,狀態,發布者姓名,發布時間,工程師,解決時間 FROM [staff] WHERE ID = '" + id + "'", conn);
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                button4.Enabled = true;
                button4.Visible = true;
            }
            groupBox1.Enabled = false;
            groupBox1.Visible = false;
            groupBox2.Enabled = true;
            groupBox2.Visible = true;
            textBox2.Text = "";
            textBox1.Text = id;
            richTextBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Noendshow();
            groupBox1.Enabled = false;
            groupBox1.Visible = false;
            groupBox4.Enabled = true;
            groupBox4.Visible = true;
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Endshow();
            groupBox1.Enabled = false;
            groupBox1.Visible = false;
            groupBox3.Enabled = true;
            groupBox3.Visible = true;
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            id = textBox1.Text;
            string a;
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT 狀態 FROM[staff]  WHERE ID = '" + id + "'", conn);
            DataTable dataTableaccount = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableaccount);
            a = dataTableaccount.Rows[0][0].ToString();
            if (a == "waiting")
            {
                conn = new SqlConnection(stCon);
                conn.Open();
                cmd = new SqlCommand("SELECT ID,緊急度,狀態,發布者姓名,發布時間 FROM [staff] WHERE ID = '" + id + "'", conn);
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                button4.Enabled = false;
                button4.Visible = false;
            }
            else if (a == "processing")
            {
                conn = new SqlConnection(stCon);
                conn.Open();
                cmd = new SqlCommand("SELECT ID,緊急度,狀態,發布者姓名,發布時間 FROM [staff] WHERE ID = '" + id + "'", conn);
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                button4.Enabled = false;
                button4.Visible = false;
            }
            else if (a == "nobug")
            {
                conn = new SqlConnection(stCon);
                conn.Open();
                cmd = new SqlCommand("SELECT ID,緊急度,狀態,發布者姓名,發布時間,解決時間 FROM [staff] WHERE ID = '" + id + "'", conn);
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                button4.Enabled = false;
                button4.Visible = false;
            }
            else
            {
                conn = new SqlConnection(stCon);
                conn.Open();
                cmd = new SqlCommand("SELECT ID,緊急度,狀態,發布者姓名,發布時間,工程師,解決時間 FROM [staff] WHERE ID = '" + id + "'", conn);
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                button4.Enabled = true;
                button4.Visible = true;
            }
            richTextBox1.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            id = textBox1.Text;
            string link;
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT 檔案 FROM[staff]  WHERE ID = '" + id + "'", conn);
            DataTable dataTableaccount = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableaccount);
            link = dataTableaccount.Rows[0][0].ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            id = textBox1.Text;
            string text;
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT 敘述 FROM[staff]  WHERE ID = '" + id + "'", conn);
            DataTable dataTableaccount = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableaccount);
            text = dataTableaccount.Rows[0][0].ToString();
            richTextBox1.Text = text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            id = textBox1.Text;
            string text;
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT 解決報告 FROM[staff]  WHERE ID= '" + id + "'", conn);
            DataTable dataTableaccount = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableaccount);
            text = dataTableaccount.Rows[0][0].ToString();
            richTextBox1.Text = text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox1.Visible = true;
            groupBox2.Enabled = false;
            groupBox2.Visible = false;
            textBox1.Text = "";
            richTextBox1.Text = "";
            show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox1.Visible = true;
            groupBox3.Enabled = false;
            groupBox3.Visible = false;
            textBox3.Text = "";
            richTextBox1.Text = "";
            show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            id = textBox3.Text;
            string link;
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT 檔案 FROM[staff]  WHERE ID = '" + id + "'", conn);
            DataTable dataTableaccount = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableaccount);
            link = dataTableaccount.Rows[0][0].ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            id = textBox3.Text;
            string text;
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT 敘述 FROM[staff]  WHERE ID = '" + id + "'", conn);
            DataTable dataTableaccount = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableaccount);
            text = dataTableaccount.Rows[0][0].ToString();
            richTextBox1.Text = text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            id = textBox3.Text;
            string text;
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT 解決報告 FROM[staff]  WHERE ID = '" + id + "'", conn);
            DataTable dataTableaccount = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableaccount);
            text = dataTableaccount.Rows[0][0].ToString();
            richTextBox1.Text = text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox1.Visible = true;
            groupBox4.Enabled = false;
            groupBox4.Visible = false;
            textBox4.Text = "";
            show();
            richTextBox1.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            id = textBox4.Text;
            string link;
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT 檔案 FROM[staff]  WHERE ID = '" + id + "'", conn);
            DataTable dataTableaccount = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableaccount);
            link = dataTableaccount.Rows[0][0].ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            id = textBox4.Text;
            string text;
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT 敘述 FROM[staff]  WHERE ID = '" + id + "'", conn);
            DataTable dataTableaccount = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableaccount);
            text = dataTableaccount.Rows[0][0].ToString();
            richTextBox1.Text = text;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            button11.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            button10.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button15_MouseEnter(object sender, EventArgs e)
        {
            button15.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button15_MouseLeave(object sender, EventArgs e)
        {
            button15.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button14_MouseEnter(object sender, EventArgs e)
        {
            button14.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {
            button14.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {
            button12.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
            button12.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button18_MouseEnter(object sender, EventArgs e)
        {
            button18.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button18_MouseLeave(object sender, EventArgs e)
        {
            button18.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button17_MouseEnter(object sender, EventArgs e)
        {
            button17.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button17_MouseLeave(object sender, EventArgs e)
        {
            button17.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}
