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
    public partial class markaguncelle : Form
    {
        public markaguncelle()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;database=uygunagetir;uid=root");
        public int marka_id;
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            string marka_adi = textBox1.Text;
            MySqlCommand guncelle = new MySqlCommand("UPDATE marka SET marka_adi='" + marka_adi + "' WHERE marka_id=" + marka_id + " ", baglanti);
            guncelle.ExecuteNonQuery();
            marka git = new marka();
            this.Close();
            git.Show();
            baglanti.Close();
        }

        private void markaguncelle_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand getir = new MySqlCommand("SELECT * FROM marka WHERE marka_id=" + marka_id + "", baglanti);
            MySqlDataReader oku = getir.ExecuteReader();
            oku.Read();
            textBox1.Text = oku["marka_adi"].ToString();
            oku.Close();
            baglanti.Close();
        }
    }
}
