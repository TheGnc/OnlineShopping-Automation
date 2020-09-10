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
    public partial class k_indirim : Form
    {
        public k_indirim()
        {
            InitializeComponent();
        }
        int kid, altkid;
        MySqlConnection baglanti = new MySqlConnection(baglan.bag);
        private void k_indirim_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand getir = new MySqlCommand("SELECT * FROM kategori", baglanti);
            MySqlDataReader oku = getir.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["kategori_adi"]);
            }
            oku.Close();
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string[] tarih_b = new string[3];
            string[] b_tarih = new string[3];

            string bas_tarih, bit_tarih;
            int oran;
            oran = Convert.ToInt16(comboBox3.Text);
            tarih_b = dateTimePicker1.Text.Split('.');
            b_tarih = dateTimePicker2.Text.Split('.');

            bas_tarih = tarih_b[2] + "." + tarih_b[1] + "." + tarih_b[0];
            bit_tarih = b_tarih[2] + "." + b_tarih[1] + "." + b_tarih[0];

            MySqlCommand guncelle = new MySqlCommand("UPDATE deger SET bas_tarih='" + bas_tarih + "',bit_tarih='" + bit_tarih + "',indirim_orani=" + oran + " WHERE kategori_id=" + kid + " AND altkategori_id=" + altkid + "", baglanti);
            int kont = Convert.ToInt16(guncelle.ExecuteNonQuery());
            if(kont!=0)
                MessageBox.Show("İNİDİRİM UYGULANDI");

            baglanti.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            string kategori_adi = comboBox1.Text;

            MySqlCommand sorgu = new MySqlCommand("SELECT * FROM kategori WHERE kategori_adi='" + kategori_adi + "'", baglanti);
            MySqlDataReader oku = sorgu.ExecuteReader();
            oku.Read();
            kid = Convert.ToInt16(oku["kategori_id"]);
            oku.Close();

            comboBox2.Items.Clear();
            MySqlCommand sorgu2 = new MySqlCommand("SELECT * FROM altkategori WHERE kategori_id=" + kid + "", baglanti);
            MySqlDataReader oku2 = sorgu2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox2.Items.Add(oku2["altkategori_adi"]);
            }
            oku2.Close();

            baglanti.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            string kategori_adi = comboBox2.Text;
            MySqlCommand sorgu = new MySqlCommand("SELECT * FROM altkategori WHERE altkategori_adi='" + kategori_adi + "'", baglanti);
            MySqlDataReader oku = sorgu.ExecuteReader();
            oku.Read();
            altkid = Convert.ToInt16(oku["altkategori_id"]);
            oku.Close();
            baglanti.Close();
        }
    }
}
