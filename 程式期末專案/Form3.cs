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

namespace 程式期末專案
{
    public partial class Form3 : Form
    {
        public string stCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database3.mdf;Integrated Security=True";
        public string puname;
        public string link;
        public void show()
        {
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID,緊急度,狀態,解決時間 FROM[staff] WHERE  發布者姓名 = '" + puname + "' AND (狀態 = 'solved' OR 狀態 = 'nobug')", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void buttonNO_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string text = richTextBox1.Text;
            if (text != "")
            {
                SqlConnection conn = new SqlConnection(stCon);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT*FROM[staff] ORDER BY ID DESC", conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                string strSQL = @"UPDATE [staff] SET 狀態 = 'waiting',敘述 = '" + text + "', 檔案= '" + link + "' WHERE ID ='" + id + "'";
                cmd = new SqlCommand(strSQL, conn);
                cmd.ExecuteNonQuery();
                show();
                conn.Close();
                label3.Enabled = false;
                label3.Visible = false;
                richTextBox1.Text = "";
                textBox1.Text = "";
                richTextBox1.Enabled = false;
                richTextBox1.Visible = false;
                button2.Enabled = false;
                button2.Visible = false;
            }
            else
                MessageBox.Show("未輸入敘述", "警告");
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonAddfile_Click(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.puname = puname;
            form2.pushow();
            Dispose();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT*FROM[staff] ORDER BY ID DESC", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            string id = textBox1.Text;
            string strSQL = @"UPDATE [staff] SET 狀態 = 'end' WHERE ID = '" + id+"'";
            cmd = new SqlCommand(strSQL, conn);
            cmd.ExecuteNonQuery();
            show();
            conn.Close();
            textBox1.Text = "";
        }

        private void buttonAddBUG_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT 檔案 FROM[staff]  WHERE ID = '" + id+"'", conn);
            DataTable dataTableaccount = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableaccount);
            link = dataTableaccount.Rows[0][0].ToString();
            System.Diagnostics.Process.Start(link);
            conn.Close();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void buttonAddBUG_MouseEnter(object sender, EventArgs e)
        {
            buttonAddBUG.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void buttonAddBUG_MouseLeave(object sender, EventArgs e)
        {
            buttonAddBUG.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label3.Enabled = true;
            label3.Visible = true;
            label3.Text = "敘述:";
            richTextBox1.Enabled = true;
            richTextBox1.Visible = true;
            button2.Enabled = true;
            button2.Visible = true;
            richTextBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label3.Enabled = true;
            label3.Visible = true;
            label3.Text = "解決報告:";
            richTextBox1.Enabled = true;
            richTextBox1.Visible = true;

            string id = textBox1.Text;
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

        private void textBox1_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Enabled = false;
            label3.Visible = false;
            richTextBox1.Text = "";
            richTextBox1.Enabled = false;
            richTextBox1.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ForeColor = Color.FromArgb(64, 64, 64);
        }
    }
}
