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
    public partial class altkategori : Form
    {
        public altkategori()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;database=uygunagetir;uid=root");
        MySqlDataAdapter aktar = new MySqlDataAdapter();
        DataTable tablo = new DataTable();
        public void listele()
        {
            tablo.Clear();
            MySqlCommand getir = new MySqlCommand("SELECT * FROM altkategori", baglanti);
            aktar.SelectCommand = getir;
            aktar.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        private void altkategori_Load(object sender, EventArgs e)
        {
            baglanti.Open();
        
            MySqlCommand kategori_getir = new MySqlCommand("SELECT * FROM kategori", baglanti);
            MySqlDataReader oku = kategori_getir.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["kategori_adi"].ToString());
            }
            oku.Close();
            listele();
            baglanti.Close();
        }
        int kid,akid;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            string kadi = comboBox1.SelectedItem.ToString();
            MySqlCommand getir = new MySqlCommand("SELECT * FROM kategori WHERE kategori_adi='" + kadi + "'", baglanti);
            MySqlDataReader oku = getir.ExecuteReader();
            oku.Read();
            kid =Convert.ToInt16(oku["kategori_id"].ToString());
            oku.Close();
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kadi = textBox1.Text;
            MySqlCommand kaydet = new MySqlCommand("INSERT INTO altkategori(kategori_id,altkategori_adi)values(" + kid + ",'" + kadi + "')", baglanti);
            kaydet.ExecuteNonQuery();
            listele();
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            akid = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand sil = new MySqlCommand("DELETE FROM altkategori WHERE altkategori_id=" + akid + "", baglanti);
            sil.ExecuteNonQuery();
            listele();
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            altkategoriguncelle git = new altkategoriguncelle();
            git.akid = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            this.Close();
            git.Show();
        }
    }
}
