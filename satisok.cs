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
    public partial class satisok : Form
    {
        public satisok()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection(baglan.bag);
        MySqlDataAdapter aktar = new MySqlDataAdapter();
        DataTable tablo = new DataTable();
        public void list()
        {
            tablo.Clear();
            baglanti.Open();
            MySqlCommand siparisler = new MySqlCommand("SELECT satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE satis.satici_id=1 AND satis.kargo_durum=1 AND satis.alan_id=uye.uyeid AND satis.urun_id=urun.urun_id", baglanti);
            aktar.SelectCommand = siparisler;
            aktar.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void satisok_Load(object sender, EventArgs e)
        {
            list();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                tablo.Clear();
                baglanti.Open();
                MySqlCommand siparisler = new MySqlCommand("SELECT satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE uye.ad LIKE '"+textBox1.Text+"%' AND satis.satici_id=1 AND satis.kargo_durum=1 AND satis.alan_id=uye.uyeid AND satis.urun_id=urun.urun_id", baglanti);
                aktar.SelectCommand = siparisler;
                aktar.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            else
            {
                list();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                tablo.Clear();
                baglanti.Open();
                MySqlCommand siparisler = new MySqlCommand("SELECT satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE uye.soyad LIKE '" + textBox2.Text + "%' AND satis.satici_id=1 AND satis.kargo_durum=1 AND satis.alan_id=uye.uyeid AND satis.urun_id=urun.urun_id", baglanti);
                aktar.SelectCommand = siparisler;
                aktar.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            else
            {
                list();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                tablo.Clear();
                baglanti.Open();
                MySqlCommand siparisler = new MySqlCommand("SELECT satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE urun.urun_adi LIKE '" + textBox3.Text + "%' AND satis.satici_id=1 AND satis.kargo_durum=1 AND satis.alan_id=uye.uyeid AND satis.urun_id=urun.urun_id", baglanti);
                aktar.SelectCommand = siparisler;
                aktar.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            else
            {
                list();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                tablo.Clear();
                baglanti.Open();
                MySqlCommand siparisler = new MySqlCommand("SELECT satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE satis.urun_fiyat LIKE '" + textBox4.Text + "%' AND satis.satici_id=1 AND satis.kargo_durum=1 AND satis.alan_id=uye.uyeid AND satis.urun_id=urun.urun_id", baglanti);
                aktar.SelectCommand = siparisler;
                aktar.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            else
            {
                list();
            }
        }
    }
}
