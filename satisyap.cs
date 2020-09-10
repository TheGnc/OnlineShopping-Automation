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

namespace otomasyon
{
    public partial class satisyap : Form
    {
        public satisyap()
        {
            InitializeComponent();
        }

        public int satici_id;
        MySqlConnection baglanti = new MySqlConnection(baglan.bag);
        int marka_id;
        int kategori_id;
        int altkategori_id;
        string yol, ad;
        private void satisyap_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            MySqlCommand markalar = new MySqlCommand("SELECT * FROM marka ORDER BY marka_adi ASC", baglanti);
            MySqlDataReader marka_oku = markalar.ExecuteReader();
            while (marka_oku.Read())
            {
                comboBox1.Items.Add(marka_oku["marka_adi"]);
            }
            marka_oku.Close();

            MySqlCommand kategori = new MySqlCommand("SELECT * FROM kategori ORDER BY kategori_adi ASC", baglanti);
            MySqlDataReader kategori_oku = kategori.ExecuteReader();
            while (kategori_oku.Read())
            {
                comboBox2.Items.Add(kategori_oku["kategori_adi"]);
            }
            kategori_oku.Close();

            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            string marka_adi = comboBox1.Text;
            MySqlCommand marka_id_getir = new MySqlCommand("SELECT * FROM marka WHERE marka_adi='" + marka_adi + "'", baglanti);
            MySqlDataReader marka_id_oku = marka_id_getir.ExecuteReader();
            marka_id_oku.Read();
            marka_id = Convert.ToInt16(marka_id_oku["marka_id"]);
            marka_id_oku.Close();
            baglanti.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            string kategori_adi = comboBox2.Text;
            MySqlCommand kategori_id_getir = new MySqlCommand("SELECT * FROM kategori WHERE kategori_adi='"+kategori_adi+"'",baglanti);
            MySqlDataReader kategori_id_oku = kategori_id_getir.ExecuteReader();
            kategori_id_oku.Read();
            kategori_id = Convert.ToInt16(kategori_id_oku["kategori_id"]);
            kategori_id_oku.Close();

            comboBox3.Items.Clear();
            MySqlCommand alt_kategori_getir = new MySqlCommand("SELECT * FROM altkategori WHERE kategori_id=" + kategori_id + "", baglanti);
            MySqlDataReader alt_kategori_oku = alt_kategori_getir.ExecuteReader();
            while (alt_kategori_oku.Read())
            {
                comboBox3.Items.Add(alt_kategori_oku["altkategori_adi"]);
            }
            alt_kategori_oku.Close();

            baglanti.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            string alt_kategori_adi=comboBox3.Text;
            MySqlCommand alt_kategori_id = new MySqlCommand("SELECT * FROM altkategori WHERE altkategori_adi='" + alt_kategori_adi + "' ", baglanti);
            MySqlDataReader oku = alt_kategori_id.ExecuteReader();
            oku.Read();
            altkategori_id = Convert.ToInt16(oku["altkategori_id"]);
            oku.Close();
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                yol = openFileDialog1.FileName;
                ad = openFileDialog1.SafeFileName;
                label9.Text = ad;
                pictureBox1.Image = Image.FromFile(yol);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
