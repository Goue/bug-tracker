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
                if (staccount == arraylevel[0, i])
                {
                    if (stpassword == arraylevel[1, i])
                    {
                        stlevel = arraylevel[2, i];
                        Form1.ActiveForm.Opacity = 0;
                        Form2 form2 = new Form2();
                        form2.ShowDialog();
                        break;
                    }
                }
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
    }
}

