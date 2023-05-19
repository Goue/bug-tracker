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
    public partial class Form2 : Form
    {
        public string stCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database3.mdf;Integrated Security=True";
        public string puname;
        public string a = "";
        public void pushow()
        {
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID,緊急度,狀態,發布時間 FROM [staff] WHERE 發布者姓名 = '" + puname + "' AND (狀態 = 'waiting' OR 狀態 = 'processing') ORDER BY ID", conn);
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            /*SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID,狀態 FROM[staff] WHERE (狀態 = 'solved' OR 狀態 = 'nobug') ORDER BY ID DESC", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            string a = "", b = "", x = "";

            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][1].ToString() == "solved")
                    {
                        if (i == 0)
                            a = dt.Rows[i][0].ToString();
                        else
                            a = a + "  " + dt.Rows[i][0].ToString();
                    }
                    else if (dt.Rows[i][1].ToString() == "nobug")
                    {
                        if (i == 0)
                            b = dt.Rows[i][0].ToString();
                        else
                            b = b + "  " + dt.Rows[i][0].ToString();
                    }
                }
                if (a != "" & b != "")
                    x = "id:" + a + "以解決，id:" + b + "無發現BUG，請做確認。";
                else if (a != "")
                    x = "id:" + a + "以解決，請做確認。";
                else if (b != "")
                    x = "id:" + b + "無發現BUG，請做確認。";
                MessageBox.Show(x, "通知");
            }
            conn.Close();*/
            pushow();
        }

        private void buttonAddBUG_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.name = puname;
            form6.Show();
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            button4.Visible = true;
            textBox1.Visible = true;
            button5.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.puname = puname;
            form3.Show();
            Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(64, 64, 64);
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(64, 64, 64);
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(52, 158, 151);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(125,52, 158, 151);
        }
        private void buttonAddBUG_MouseEnter(object sender, EventArgs e)
        {
            buttonAddBUG.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void buttonAddBUG_MouseLeave(object sender, EventArgs e)
        {
            buttonAddBUG.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label2.Visible = false;
            button4.Visible = false;
            textBox1.Visible = false;
            button5.Visible =false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT*FROM[staff]", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            string strSQL = @"DELETE FROM [staff] WHERE ID = '" + id+"'" ;
            cmd = new SqlCommand(strSQL, conn);
            cmd.ExecuteNonQuery();
            pushow();
            conn.Close();
            textBox1.Text = "";
            label2.Visible = false;
            button4.Visible = false;
            textBox1.Visible = false;
            button5.Visible = false;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            
        }
    }

}
