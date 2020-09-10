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
    public partial class k_satisok : Form
    {
        public k_satisok()
        {
            InitializeComponent();
        }
        public int kid;
        MySqlConnection baglanti = new MySqlConnection(baglan.bag);
        MySqlDataAdapter aktar = new MySqlDataAdapter();
        DataTable tablo = new DataTable();

        public void listele()
        {
            tablo.Clear();
            baglanti.Open();
            MySqlCommand getir = new MySqlCommand("SELECT satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE satis.satici_id=" + kid + " AND kargo_durum="+1+" AND satis.urun_id=urun.urun_id AND satis.alan_id=uye.uyeid ", baglanti);
            aktar.SelectCommand = getir;
            aktar.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void k_satisok_Load(object sender, EventArgs e)
        {
            listele();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                tablo.Clear();
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("SELECT satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE uye.ad LIKE '"+textBox1.Text+"%' AND satis.satici_id=" + kid + " AND kargo_durum=" + 1 + " AND satis.urun_id=urun.urun_id AND satis.alan_id=uye.uyeid ", baglanti);
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
                MySqlCommand getir = new MySqlCommand("SELECT satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE uye.soyad LIKE '" + textBox2.Text + "%' AND satis.satici_id=" + kid + " AND kargo_durum=" + 1 + " AND satis.urun_id=urun.urun_id AND satis.alan_id=uye.uyeid ", baglanti);
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
                MySqlCommand getir = new MySqlCommand("SELECT satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE urun.urun_adi LIKE '" + textBox3.Text + "%' AND satis.satici_id=" + kid + " AND kargo_durum=" + 1 + " AND satis.urun_id=urun.urun_id AND satis.alan_id=uye.uyeid ", baglanti);
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                tablo.Clear();
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("SELECT satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE satis.urun_fiyat LIKE '" + textBox4.Text + "%' AND satis.satici_id=" + kid + " AND kargo_durum=" + 1 + " AND satis.urun_id=urun.urun_id AND satis.alan_id=uye.uyeid ", baglanti);
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
