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
using System.Diagnostics.Eventing.Reader;

namespace Kutuphane_v2
{
    public partial class ana_ekran : Form
    {
        public ana_ekran()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=kutuphane.mdb");




        void verilerigoster()
        {
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM kitaplar", conn);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;

            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==""&&textBox2.Text==""&&textBox3.Text==""&&textBox4.Text==""&&textBox5.Text=="")
            {
                MessageBox.Show("VERİLERİ EKSİKSİZ DOLDURUN!");
            }


            else
            {

             string sorgu = "INSERT INTO kitaplar (adi,yazar_adi,sayfa_sayisi,konum,tur) " +
                            "VALUES ('"+textBox1.Text+"','"+textBox2.Text+"',"+textBox3.Text+",'"+textBox4.Text+"','"+textBox5.Text+"')";

            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sorgu,conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            verilerigoster();
              
            }
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            }
     

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox8.Text==""&&textBox9.Text==""&&textBox10.Text==""&&textBox11.Text==""&&textBox12.Text=="" && textBox13.Text == "")
            {
                MessageBox.Show("VERİLERİ EKSİKSİZ GİRİN!");
            }
            else
            {

                string sorgu = "UPDATE kitaplar SET adi='" + textBox8.Text + "',yazar_adi='" + textBox9.Text + "',sayfa_sayisi='" + textBox10.Text + "',konum='" + textBox11.Text + "',tur='" + textBox12.Text + "'WHERE Kimlik=" + textBox13.Text + "";

                OleDbCommand guncelle = new OleDbCommand(sorgu, conn);
                conn.Open();
                guncelle.ExecuteNonQuery();
                conn.Close();
               
            }

              verilerigoster();


        }

        private void button5_Click(object sender, EventArgs e)
        {
          DialogResult deneme_buton= MessageBox.Show("SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ", "UYARI!",MessageBoxButtons.YesNo);
            if (deneme_buton == DialogResult.Yes)
            {
                string sorgu = "DELETE FROM kitaplar WHERE Kimlik=" + textBox7.Text + "";

                OleDbCommand sql_komut = new OleDbCommand(sorgu, conn);

                conn.Open();
                sql_komut.ExecuteNonQuery();
                conn.Close();
                verilerigoster();
            }
            else if  ( textBox7.Text == "")
            {            MessageBox.Show("VERİLERİ EKSİKSİZ GİRİN!");

            }

            else
            {
                MessageBox.Show("veriler silinmedİ");
                  
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            
            textBox9.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
