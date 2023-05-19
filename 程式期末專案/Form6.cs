using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace 程式期末專案
{
    public partial class Form6 : Form
    {
        public string stCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database3.mdf;Integrated Security=True";
        public string pusttext;
        public string pustlink;
        public string pustlevel;
        public string name;
        public Form6()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if ((radioButton2.Checked == true || radioButton1.Checked ==true) & pusttext != "" & pustlink != "")
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                pustlink = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true & pusttext != "" & pustlink != "")
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true & pusttext != "" & pustlink != "")
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                pustlink = folderBrowserDialog1.SelectedPath;
            }
             
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.puname = name;
            form2.pushow();
            Dispose();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pusttext = richTextBox1.Text;
            if (radioButton1.Checked == true)
                pustlevel = "NotUrgent";
            else if (radioButton2.Checked == true)
                pustlevel = "Urgent";
            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT*FROM[staff] ORDER BY ID DESC", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            string xid ,id;
            int a;
            xid = dt.Rows[0]["ID"].ToString();

            if(int.Parse(xid.Substring(3, 1)) != 9)
            {
                a = int.Parse(xid.Substring(3, 1)) + 1;
                id = xid.Substring(0, 1) + xid.Substring(1, 1) + xid.Substring(2, 1) + a;
            }
            else
            {
                if(int.Parse(xid.Substring(2, 1)) != 9)
                {
                    a = int.Parse(xid.Substring(2, 1)) + 1;
                    id = xid.Substring(0, 1) + xid.Substring(1, 1)  + a+0;
                }
                else
                {
                    a = int.Parse(xid.Substring(1, 1)) + 1;
                    id = xid.Substring(0, 1) + a + 0 + 0;
                }
            }
            string today = DateTime.Now.ToString("d");
            string strSQL = @"INSERT INTO [staff](ID,發布時間,發布者姓名,檔案,敘述,緊急度,狀態)VALUES('" + id + "','" + today + "','" + name + "','" + pustlink + "','" + pusttext + "','" + pustlevel + "','waiting')";
            cmd = new SqlCommand(strSQL, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
            richTextBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            button2.Enabled = false;
            Form2 form2 = new Form2();
            form2.Show();
            form2.puname = name;
            form2.pushow();
            Dispose();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(64, 64, 64);
        }
    }
}
