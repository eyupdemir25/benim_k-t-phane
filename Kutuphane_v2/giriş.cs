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
    public partial class giriş : Form
    {
        public giriş()
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
                    ana_ekran frm1 = new ana_ekran();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "")
            {
                MessageBox.Show("VERİLERİ EKSİKSİZ DOLDURUN!");
            }

            else
            {
                if (textBox4.Text == textBox5.Text)
                {
                    string sorgu = "INSERT INTO kullanici (ad,parola) " +
                               "VALUES ('" + textBox3.Text + "','" + textBox4.Text + "')";

                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sorgu, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("kayıt başarılı");
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
                else
                {
                    MessageBox.Show("parola doğrulayınız!!");
                }

                


            }
        }
    }
}
