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
    public partial class altkategoriguncelle : Form
    {
        public altkategoriguncelle()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;database=uygunagetir;uid=root");
        public int akid;
        private void altkategoriguncelle_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            MySqlCommand getir = new MySqlCommand("SELECT * FROM altkategori WHERE altkategori_id=" + akid + "", baglanti);
            MySqlDataReader oku = getir.ExecuteReader();
            oku.Read();
            textBox1.Text = oku["altkategori_adi"].ToString();
            oku.Close();
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kadi=textBox1.Text;
            MySqlCommand guncelle = new MySqlCommand("UPDATE altkategori SET altkategori_adi='" + kadi + "' WHERE altkategori_id=" + akid + "", baglanti);
            guncelle.ExecuteNonQuery();
            altkategori git = new altkategori();
            this.Close();
            git.Show();
            baglanti.Close();
        }
    }
}
