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
    public partial class kategoriguncelle : Form
    {
        public kategoriguncelle()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;database=uygunagetir;uid=root");
        public int kategori_id;
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            string marka_adi = textBox1.Text;
            MySqlCommand guncelle = new MySqlCommand("UPDATE kategori SET kategori_adi='" + marka_adi + "' WHERE kategori_id=" + kategori_id + "", baglanti);
            guncelle.ExecuteNonQuery();
            kategori git = new kategori();
            this.Close();
            git.Show();

            baglanti.Close();
        }

        private void kategoriguncelle_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            MySqlCommand getir = new MySqlCommand("SELECT * FROM kategori WHERE kategori_id=" + kategori_id + "", baglanti);
            MySqlDataReader oku = getir.ExecuteReader();
            oku.Read();
            textBox1.Text = oku["kategori_adi"].ToString();
            oku.Close();

            baglanti.Close();
        }
    }
}
