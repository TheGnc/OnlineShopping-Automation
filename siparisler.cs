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
    public partial class siparisler : Form
    {
        public siparisler()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection(baglan.bag);
        MySqlDataAdapter aktar = new MySqlDataAdapter();
        DataTable tablo = new DataTable();
        public void listele()
        {
            tablo.Clear();
            baglanti.Open();
            MySqlCommand siparisler = new MySqlCommand("SELECT satis.satis_id,satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE satis.satici_id=1 AND satis.kargo_durum!=1 AND satis.alan_id=uye.uyeid AND satis.urun_id=urun.urun_id", baglanti);
            aktar.SelectCommand = siparisler;
            aktar.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void siparisler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string mad = textBox1.Text;
                tablo.Clear();
                baglanti.Open();
                MySqlCommand siparisler = new MySqlCommand("SELECT satis.satis_id,satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE uye.ad LIKE '" + mad + "%' AND satis.satici_id=1 AND satis.kargo_durum!=1 AND satis.alan_id=uye.uyeid AND satis.urun_id=urun.urun_id", baglanti);
                aktar.SelectCommand = siparisler;
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
                string msad = textBox2.Text;
                tablo.Clear();
                baglanti.Open();
                MySqlCommand siparisler = new MySqlCommand("SELECT satis.satis_id,satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE uye.soyad LIKE '" + msad + "%' AND satis.satici_id=1 AND satis.kargo_durum!=1 AND satis.alan_id=uye.uyeid AND satis.urun_id=urun.urun_id", baglanti);
                aktar.SelectCommand = siparisler;
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
                string f = textBox3.Text;
                tablo.Clear();
                baglanti.Open();
                MySqlCommand siparisler = new MySqlCommand("SELECT satis.satis_id,satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE satis.urun_fiyat LIKE '" + f + "%' AND satis.satici_id=1 AND satis.kargo_durum!=1 AND satis.alan_id=uye.uyeid AND satis.urun_id=urun.urun_id", baglanti);
                aktar.SelectCommand = siparisler;
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
                string uad = textBox4.Text;
                tablo.Clear();
                baglanti.Open();
                MySqlCommand siparisler = new MySqlCommand("SELECT satis.satis_id,satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE urun.urun_adi LIKE '" + uad + "%' AND satis.satici_id=1 AND satis.kargo_durum!=1 AND satis.alan_id=uye.uyeid AND satis.urun_id=urun.urun_id", baglanti);
                aktar.SelectCommand = siparisler;
                aktar.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            else
            {
                listele();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            kargoguncelle git = new kargoguncelle();
            git.satis_id = id;
            git.rutbe = 1;
            git.Show();
            this.Hide();
        }
    }
}
