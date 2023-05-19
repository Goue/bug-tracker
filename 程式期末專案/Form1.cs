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
    public partial class Form1 : Form
    {
        public string stCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        public string stname = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void textaccount_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void buttonSignin_Click(object sender, EventArgs e)
        {
            string staccount = textaccount.Text;
            string stpassword = textpassword.Text;
            string stlevel = "";

            SqlConnection conn = new SqlConnection(stCon);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT account FROM[level]", conn);
            DataTable dataTableaccount = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTableaccount);

            cmd = new SqlCommand("SELECT password FROM[level]", conn);
            DataTable dataTablepassword = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dataTablepassword);

            cmd = new SqlCommand("SELECT level FROM[level]", conn);
            DataTable dataTablelevel = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dataTablelevel);

            string[,] arraylevel = new string[3, dataTableaccount.Rows.Count];

            for (int i = 0; i < dataTableaccount.Rows.Count; i++)
            {
                arraylevel[0, i] = dataTableaccount.Rows[i][0].ToString();
                arraylevel[1, i] = dataTablepassword.Rows[i][0].ToString();
                arraylevel[2, i] = dataTablelevel.Rows[i][0].ToString();
            }
            for (int i = 0; i < dataTableaccount.Rows.Count; i++)
            {
                if (staccount == arraylevel[0, i] & stpassword == arraylevel[1, i])
                {
                    stlevel = arraylevel[2, i];
                    if (stlevel == "staff")
                       {
                        stname = arraylevel[0, i];
                        Form2 form2 = new Form2();
                        form2.puname = stname;
                        form2.Show();
                        textaccount.Text = "";
                        textpassword.Text = "";
                        this.Hide();
                    }
                    else if(stlevel=="test")
                    {
                        stname = arraylevel[0, i];
                        Form4 form4 = new Form4();
                        form4.puname = stname;
                        form4.Show();
                        textaccount.Text = "";
                        textpassword.Text = "";
                        this.Hide();
                    }
                    else if(stlevel == "engineer")
                    {
                        stname = arraylevel[0, i];
                        Form5 form5 = new Form5();
                        form5.pustengineer = stname;
                        form5.Show();
                        textaccount.Text = "";
                        textpassword.Text = "";
                        this.Hide();
                    }
                    else if (stlevel == "administrator")
                    {
                        stname = arraylevel[0, i];
                        Form8 form8 = new Form8();
                        form8.Show();
                        textaccount.Text = "";
                        textpassword.Text = "";
                        this.Hide();
                    }
                    break;
                }
                if(i== dataTableaccount.Rows.Count-1)
                    MessageBox.Show("登入失敗", "警告");
            }
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
           
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}

