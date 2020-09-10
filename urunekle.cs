using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace otomasyon
{
    public partial class urunekle : Form
    {
        public urunekle()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;database=uygunagetir;uid=root");
        int marka_id, kategori_id, altkategori_id;
        string yol, ad;
        public int satici_id;
       
        private void urunekle_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            MySqlCommand marka_sorgu = new MySqlCommand("SELECT * FROM marka", baglanti);
            MySqlDataReader marka_oku = marka_sorgu.ExecuteReader();
            while (marka_oku.Read())
            {
                comboBox1.Items.Add(marka_oku["marka_adi"].ToString());
            }
            marka_oku.Close();
           
            MySqlCommand kategori_sorgu = new MySqlCommand("SELECT * FROM kategori", baglanti);
            MySqlDataReader kategori_oku = kategori_sorgu.ExecuteReader();
            while (kategori_oku.Read())
            {
                comboBox2.Items.Add(kategori_oku["kategori_adi"].ToString());
            }
            kategori_oku.Close();


            baglanti.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            baglanti.Open();

            string kategori_adi = comboBox2.Text;
            MySqlCommand sorgu = new MySqlCommand("SELECT * FROM kategori WHERE kategori_adi='" + kategori_adi + "'", baglanti);
            MySqlDataReader oku = sorgu.ExecuteReader();
            oku.Read();
            kategori_id = Convert.ToInt16(oku["kategori_id"].ToString());
            oku.Close();

            
            comboBox3.Items.Clear();
            MySqlCommand altkategori_sorgu = new MySqlCommand("SELECT * FROM altkategori WHERE kategori_id=" + kategori_id + "", baglanti);
            MySqlDataReader altkategori_oku = altkategori_sorgu.ExecuteReader();
            while (altkategori_oku.Read())
            {
                comboBox3.Items.Add(altkategori_oku["altkategori_adi"].ToString());
            }
            altkategori_oku.Close();

            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            string marka_adi = comboBox1.Text;
            MySqlCommand sorgu = new MySqlCommand("SELECT * FROM marka WHERE marka_adi='" + marka_adi + "'", baglanti);
            MySqlDataReader oku = sorgu.ExecuteReader();
            oku.Read();
            marka_id = Convert.ToInt16(oku["marka_id"].ToString());
            oku.Close();
            baglanti.Close();
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            string altkategori_adi = comboBox3.Text;
            MySqlCommand sorgu = new MySqlCommand("SELECT * FROM altkategori WHERE altkategori_adi='"+altkategori_adi+"'", baglanti);
            MySqlDataReader oku1 = sorgu.ExecuteReader();
            oku1.Read();
            altkategori_id =Convert.ToInt16(oku1["altkategori_id"].ToString());
            oku1.Close();
            baglanti.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                yol = openFileDialog1.FileName;
                ad = openFileDialog1.SafeFileName;
                label11.Text = ad;
                pictureBox1.Image = Image.FromFile(yol);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();

            string urunadi, ozellik;
            int fiyat, stok;
            urunadi = textBox1.Text;
            ozellik = textBox4.Text;
            fiyat = Convert.ToInt16(textBox2.Text);
            stok = Convert.ToInt16(textBox3.Text);

            MySqlCommand urunkaydet = new MySqlCommand("insert into urun(satici_id,marka_id,kategori_id,altkategori_id,urun_adi,urun_resmi,urun_ozellik,urun_stok,vitrin,gorunum)values(" + satici_id + "," + marka_id + "," + kategori_id + "," + altkategori_id + ",'" + urunadi + "','" + ad + "','" + ozellik + "'," + stok + "," + 0 + "," + 1 + ")", baglanti);
            int kont = Convert.ToInt16(urunkaydet.ExecuteNonQuery());
            if (kont == 1)
            {
                MySqlCommand sonidgetir = new MySqlCommand("SELECT * FROM urun ORDER BY urun_id DESC LIMIT 1", baglanti);
                MySqlDataReader oku = sonidgetir.ExecuteReader();
                oku.Read();
                int sonid = Convert.ToInt16(oku["urun_id"]);
                oku.Close();

                MySqlCommand degerkaydet = new MySqlCommand("insert into deger(urun_id,kategori_id,altkategori_id,fiyat)values(" + sonid + "," + kategori_id + "," + altkategori_id + "," + fiyat + ")", baglanti);
                int kont2 = Convert.ToInt16(degerkaydet.ExecuteNonQuery());
                if (kont2 == 1)
                {
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    label9.Text = "";
                }

            }

            pictureBox1.Image.Save(@"C:\wamp\www\uygunagetir\urunresimleri\" + ad);
            baglanti.Close();
        }
    }
}
