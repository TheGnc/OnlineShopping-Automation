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
    public partial class uye : Form
    {
        public uye()
        {
            InitializeComponent();
        }
        public int uye_id;

        MySqlConnection baglanti = new MySqlConnection(baglan.bag);
        MySqlDataAdapter aktar = new MySqlDataAdapter();
        DataTable tablo = new DataTable();
        public void listele()
        {
            tablo.Clear();
            baglanti.Open();
            MySqlCommand getir=new MySqlCommand("SELECT satis.satis_id,satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE satis.satici_id="+uye_id+" AND satis.kargo_durum!=1 AND satis.urun_id=urun.urun_id AND satis.alan_id=uye.uyeid",baglanti);
            aktar.SelectCommand=getir;
            aktar.Fill(tablo);
            dataGridView1.DataSource=tablo;
            baglanti.Close();
        }

        private void uye_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                tablo.Clear();
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("SELECT satis.satis_id,satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE satis.satici_id=" + uye_id + " AND uye.ad LIKE '"+textBox1.Text+"%' AND satis.kargo_durum!=1 AND satis.urun_id=urun.urun_id AND satis.alan_id=uye.uyeid", baglanti);
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
                MySqlCommand getir = new MySqlCommand("SELECT satis.satis_id,satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE satis.satici_id=" + uye_id + " AND uye.soyad LIKE '" + textBox2.Text + "%' AND satis.kargo_durum!=1 AND satis.urun_id=urun.urun_id AND satis.alan_id=uye.uyeid", baglanti);
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
                MySqlCommand getir = new MySqlCommand("SELECT satis.satis_id,satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE satis.satici_id=" + uye_id + " AND urun.urun_adi LIKE '" + textBox3.Text + "%' AND satis.kargo_durum!=1 AND satis.urun_id=urun.urun_id AND satis.alan_id=uye.uyeid", baglanti);
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
                MySqlCommand getir = new MySqlCommand("SELECT satis.satis_id,satis.tarih,uye.ad,uye.soyad,urun.urun_adi,satis.urun_fiyat,satis.urun_adet,satis.toplam_fiyat FROM satis,urun,uye WHERE satis.satici_id=" + uye_id + " AND satis.urun_fiyat LIKE '" + textBox4.Text + "%' AND satis.kargo_durum!=1 AND satis.urun_id=urun.urun_id AND satis.alan_id=uye.uyeid", baglanti);
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

        private void üRÜNLERİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k_urunlerim git = new k_urunlerim();
            git.uid = uye_id;
            git.Show();
        }

        private void aLDIKLARIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aldiklarim git = new aldiklarim();
            git.kid = uye_id;
            git.Show();
        }

        private void sATTIKLARIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k_satisok git = new k_satisok();
            git.kid = uye_id;
            git.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            kargoguncelle git = new kargoguncelle();
            git.satis_id = id;
            git.rutbe = 2;
            git.Show();
            this.Hide();
        }

        private void üRÜNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            satisyap git = new satisyap();
            git.satici_id = uye_id;
            git.Show();

        }
    }
}
