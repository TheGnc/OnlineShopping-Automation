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
    public partial class aldiklarim : Form
    {
        public aldiklarim()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection(baglan.bag);
        MySqlDataAdapter aktar = new MySqlDataAdapter();
        DataTable tablo = new DataTable();
        public int kid;
        public void listele()
        {
            tablo.Clear();
            baglanti.Open();
            MySqlCommand getir = new MySqlCommand("SELECT satis.tarih,uye.kadi,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM urun,satis,uye WHERE satis.alan_id=" + kid + " AND kargo_durum=1 AND urun.urun_id=satis.urun_id AND satis.satici_id=uye.uyeid", baglanti);
            aktar.SelectCommand = getir;
            aktar.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void aldiklarim_Load(object sender, EventArgs e)
        {
            listele();
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                tablo.Clear();
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("SELECT satis.tarih,uye.kadi,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM urun,satis,uye WHERE satis.kargo_durum=1 AND satis.alan_id=" + kid + " AND urun.urun_adi LIKE '" + textBox1.Text + "%' AND urun.urun_id=satis.urun_id AND satis.satici_id=uye.uyeid", baglanti);
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
                MySqlCommand getir = new MySqlCommand("SELECT satis.tarih,uye.kadi,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM urun,satis,uye WHERE satis.kargo_durum=1 AND satis.alan_id=" + kid + " AND satis.urun_fiyat LIKE '" + textBox2.Text + "%' AND urun.urun_id=satis.urun_id AND satis.satici_id=uye.uyeid", baglanti);
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
                MySqlCommand getir = new MySqlCommand("SELECT satis.tarih,uye.kadi,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM urun,satis,uye WHERE satis.kargo_durum=1 AND satis.alan_id=" + kid + " AND satis.toplam_fiyat LIKE '" + textBox3.Text + "%' AND urun.urun_id=satis.urun_id AND satis.satici_id=uye.uyeid", baglanti);
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
