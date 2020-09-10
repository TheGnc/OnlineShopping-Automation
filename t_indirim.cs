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
    public partial class t_indirim : Form
    {
        public t_indirim()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection(baglan.bag);
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string[] tarih_b = new string[3];
            string[] b_tarih = new string[3];
   
            string bas_tarih, bit_tarih;
            int oran;
            oran = Convert.ToInt16(comboBox1.Text);
            tarih_b = dateTimePicker1.Text.Split('.');
            b_tarih = dateTimePicker2.Text.Split('.');

            bas_tarih = tarih_b[2] + "." + tarih_b[1] + "." + tarih_b[0];
            bit_tarih = b_tarih[2] + "." + b_tarih[1] + "." + b_tarih[0];
            //string tarih = DateTime.Now.ToShortDateString();
            //MessageBox.Show(bas_tarih+"-"+bit_tarih);
            MySqlCommand sorgu = new MySqlCommand("UPDATE deger SET bas_tarih='" + bas_tarih + "',bit_tarih='" + bit_tarih + "',indirim_orani=" + oran + " WHERE deger_id > 0 ", baglanti);
            int kont = Convert.ToInt16(sorgu.ExecuteNonQuery());
            if (kont !=0)
            {
                MessageBox.Show("İndirim Uygulandı");
            }
            
          
        }
    }
}