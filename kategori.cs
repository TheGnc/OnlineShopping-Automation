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
    public partial class kategori : Form
    {
        public kategori()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;database=uygunagetir;uid=root");
        MySqlDataAdapter aktar = new MySqlDataAdapter();
        DataTable tablo = new DataTable();
        int kategori_id;
        public void listele()
        {
            tablo.Clear();
            MySqlCommand getir = new MySqlCommand("SELECT * FROM kategori", baglanti);
            aktar.SelectCommand = getir;
            aktar.Fill(tablo);
            dataGridView1.DataSource = tablo;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kadi = textBox1.Text;
            MySqlCommand kaydet = new MySqlCommand("INSERT INTO kategori(kategori_adi)values('" + kadi + "')", baglanti);
            kaydet.ExecuteNonQuery();
            listele();
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand sil = new MySqlCommand("DELETE FROM kategori WHERE kategori_id=" + kategori_id + "", baglanti);
            sil.ExecuteNonQuery();
            listele();
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            kategori_id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            kategoriguncelle git = new kategoriguncelle();
            git.kategori_id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            this.Close();
            git.Show();
        }

        private void kategori_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            listele();
            baglanti.Close();

        }
    }
}
