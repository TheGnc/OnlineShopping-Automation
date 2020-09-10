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
    public partial class kargoguncelle : Form
    {
        public kargoguncelle()
        {
            InitializeComponent();
        }
        public int satis_id;
        public int rutbe;
        MySqlConnection baglanti = new MySqlConnection(baglan.bag);
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            int durum = comboBox1.SelectedIndex + 2;
            MySqlCommand guncelle = new MySqlCommand("UPDATE satis SET kargo_durum=" + durum + " WHERE satis_id=" + satis_id + "", baglanti);
            int kont = Convert.ToInt16(guncelle.ExecuteNonQuery());
            if (kont == 1)
            {
                MessageBox.Show("İŞLEM TAMAM");
                comboBox1.Text = "";
            }

            baglanti.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kargo_adi, kargo_no;
            kargo_adi = comboBox2.Text;
            kargo_no = textBox1.Text;
            MySqlCommand guncelle = new MySqlCommand("UPDATE satis SET kargo_adi='" + kargo_adi + "',kargo_kodu='" + kargo_no + "',kargo_durum=1 WHERE satis_id=" + satis_id + "", baglanti);
            int kont = Convert.ToInt16(guncelle.ExecuteNonQuery());
            if (kont == 1)
            {
                MessageBox.Show("Kargo Numarası Verildi");
                comboBox2.Text="";
                textBox1.Text = "";
            }
            baglanti.Close();
        }

        private void kargoguncelle_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (rutbe == 1)
            {
                yonetici y_git = new yonetici();
                y_git.Show();
                this.Hide();
            }
            else
            {
                uye u_git = new uye();
                u_git.Show();
                this.Hide();
            }
        }

        private void kargoguncelle_Load(object sender, EventArgs e)
        {

        }
    }
}
