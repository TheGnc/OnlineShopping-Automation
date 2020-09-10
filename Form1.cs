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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        sifrele sek = new sifrele();
        MySqlConnection baglanti = new MySqlConnection("server=localhost;database=uygunagetir;uid=root");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            string kadi, sifre;
            kadi = textBox1.Text;
            sifre = sek.MD5Sifrele(textBox2.Text);

            string sql="SELECT * FROM uye WHERE kadi='" + kadi + "' AND sifre='" + sifre + "'";
            MySqlCommand girisyap = new MySqlCommand(sql, baglanti);
            int varmi = Convert.ToInt16(girisyap.ExecuteScalar());
            if (varmi != 0)
            {
                MySqlCommand rutbe = new MySqlCommand(sql, baglanti);
                MySqlDataReader oku = rutbe.ExecuteReader();
                oku.Read();
                int uye_id = Convert.ToInt16(oku["uyeid"]);
                int uye_rutbe =Convert.ToInt16(oku["rutbe"]);
                oku.Close();

                if (uye_rutbe == 1)
                {
                    yonetici y_git = new yonetici();
                    y_git.uye_id = uye_id;
                    this.Hide();
                    y_git.Show();
                }
                else
                {
                    uye u_git = new uye();
                    u_git.uye_id = uye_id;
                    this.Hide();
                    u_git.Show();
                }

            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifreniz Hatalı");
            }

            baglanti.Close();
            
        }
    }
}
