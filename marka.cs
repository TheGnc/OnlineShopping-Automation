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
    public partial class marka : Form
    {
        public marka()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;database=uygunagetir;uid=root");
        MySqlDataAdapter aktar = new MySqlDataAdapter();
        DataTable tablo = new DataTable();
        public void listele()
        {
            tablo.Clear();
            MySqlCommand markagetir = new MySqlCommand("SELECT * FROM marka", baglanti);
            aktar.SelectCommand = markagetir;
            aktar.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            string marka_adi = textBox1.Text;
            MySqlCommand kaydet = new MySqlCommand("INSERT INTO marka(marka_adi) values('" + marka_adi + "')", baglanti);
            kaydet.ExecuteNonQuery();
            listele();

            baglanti.Close();
        }

        private void marka_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            listele();
            baglanti.Close();
        }

        private void sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand markasil = new MySqlCommand("DELETE FROM marka WHERE marka_id=" + marka_id + "", baglanti);
            markasil.ExecuteNonQuery();
            listele();
            baglanti.Close();
        }
        int marka_id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            marka_id =Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            markaguncelle git = new markaguncelle();
            git.marka_id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            this.Hide();
            git.Show();
        }
    }
}
