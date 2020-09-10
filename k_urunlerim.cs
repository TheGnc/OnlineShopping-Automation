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
    public partial class k_urunlerim : Form
    {
        public k_urunlerim()
        {
            InitializeComponent();
        }
        public int uid;
        MySqlConnection baglanti = new MySqlConnection(baglan.bag);
        MySqlDataAdapter aktar = new MySqlDataAdapter();
        DataTable tablo = new DataTable();

        public void listele()
        {
            tablo.Clear();
            baglanti.Open();
            MySqlCommand getir = new MySqlCommand("SELECT urun.urun_id,urun.urun_adi,deger.fiyat,urun.urun_stok FROM urun,deger WHERE urun.satici_id=" + uid + " AND urun.urun_id=deger.urun_id", baglanti);
            aktar.SelectCommand = getir;
            aktar.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void k_urunlerim_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                tablo.Clear();
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("SELECT urun.urun_id,urun.urun_adi,deger.fiyat,urun.urun_stok FROM urun,deger WHERE urun.satici_id=" + uid + " AND urun.urun_adi LIKE '"+textBox1.Text+"%' AND urun.urun_id=deger.urun_id", baglanti);
                aktar.SelectCommand = getir;
                aktar.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            else
            {
                listele();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                tablo.Clear();
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("SELECT urun.urun_id,urun.urun_adi,deger.fiyat,urun.urun_stok FROM urun,deger WHERE urun.satici_id=" + uid + " AND deger.fiyat LIKE '" + textBox2.Text + "%' AND urun.urun_id=deger.urun_id", baglanti);
                aktar.SelectCommand = getir;
                aktar.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            else
            {
                listele();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                tablo.Clear();
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("SELECT urun.urun_id,urun.urun_adi,deger.fiyat,urun.urun_stok FROM urun,deger WHERE urun.satici_id=" + uid + " AND urun.urun_stok LIKE '" + textBox3.Text + "%' AND urun.urun_id=deger.urun_id", baglanti);
                aktar.SelectCommand = getir;
                aktar.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            else
            {
                listele();
            }
        }
    }
}
