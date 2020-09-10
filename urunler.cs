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
    public partial class urunler : Form
    {
        public urunler()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection(baglan.bag);
        MySqlDataAdapter aktar = new MySqlDataAdapter();
        DataTable tablo = new DataTable();
        int urun_id=0;
        public void listele()
        {
            tablo.Clear();
            baglanti.Open();
            MySqlCommand getir = new MySqlCommand("SELECT urun.urun_id,uye.kadi,urun.urun_adi,urun.urun_stok FROM urun,uye WHERE urun.satici_id=uye.uyeid", baglanti);
            aktar.SelectCommand = getir;
            aktar.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void urunler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                string ad = textBox1.Text;
                tablo.Clear();
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("SELECT urun.urun_id,uye.kadi,urun.urun_adi,urun.urun_stok FROM urun,uye WHERE urun.urun_adi LIKE '"+ad+"%' AND  urun.satici_id=uye.uyeid", baglanti);
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

                string stok = textBox2.Text;
                tablo.Clear();
                baglanti.Open();
                MySqlCommand getir = new MySqlCommand("SELECT urun.urun_id,uye.kadi,urun.urun_adi,urun.urun_stok FROM urun,uye WHERE urun.urun_stok LIKE '" + stok + "%' AND  urun.satici_id=uye.uyeid", baglanti);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            urun_id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (urun_id != 0)
            {
                baglanti.Open();
                string resim;
                MySqlCommand urungetir = new MySqlCommand("SELECT * FROM urun WHERE urun_id=" + urun_id + "", baglanti);
                MySqlDataReader oku = urungetir.ExecuteReader();
                oku.Read();
                resim = oku["urun_resmi"].ToString();
                oku.Close();
                File.Delete(@"C:\wamp\www\uygunagetir\urunresimleri\" + resim);

                MySqlCommand urunsil = new MySqlCommand("DELETE FROM urun WHERE urun_id=" + urun_id + "", baglanti);
                int kont = Convert.ToInt16(urunsil.ExecuteNonQuery());
                if (kont == 1)
                {
                    MySqlCommand degersil = new MySqlCommand("DELETE FROM deger WHERE urun_id=" + urun_id + "", baglanti);
                    int i = Convert.ToInt16(degersil.ExecuteNonQuery());
                    if (i == 1)
                    {
                        MessageBox.Show("Ürün Kaldırıdı");
                        baglanti.Close();
                        listele();
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Ürün Şeçiniz");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            urun_id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }
    }
}
