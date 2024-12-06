using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Kutuphane_v2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=kutuphane.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "SELECT * FROM kullanici WHERE ad='"+textBox1.Text+"' AND parola='"+textBox2.Text+"'";
            OleDbCommand cmd =new OleDbCommand(sql, conn);
            OleDbDataReader oku = cmd.ExecuteReader();
            

            if (oku.Read())
            {
                if (oku.GetString(3)=="0") 
                {
                    mudur fmudur = new mudur();
                    fmudur.ShowDialog();
                }
                else if (oku.GetString(3)=="1")
                {
                    Form1 frm1 = new Form1();
                    frm1.ShowDialog();
                }
                else
                {
                    ogrenci frm = new ogrenci();//MessageBox.Show("giriş başarılı");
                    this.Hide();
                    frm.ShowDialog();

                }
                //MessageBox.Show("giriş başarılı");
                
            }
            else
            {

                MessageBox.Show("HATALI!!");
            }
            conn.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
