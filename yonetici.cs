using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace otomasyon
{
    public partial class yonetici : Form
    {
        public yonetici()
        {
            InitializeComponent();
        }

        public int uye_id;
        
       
        private void yonetici_Load(object sender, EventArgs e)
        {
        }

        private void üRÜNEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void aLTKATEGORİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            marka m_git = new marka();
            m_git.Show();
        }

        private void aLTKATEGORİDÜZENLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kategori git = new kategori();
            git.Show();
        }

        private void kATEGORİDÜZENLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void aLTKATEGORİDÜZENLEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            altkategori git = new altkategori();
            git.Show();
        }

        private void sİPARİŞLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            satisok git = new satisok();
            git.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void üRÜNEKLEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            urunekle git = new urunekle();
            git.satici_id = uye_id;
            git.MdiParent = this;
            git.Show();
        }

        private void tÜMÜRÜNLERDEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t_indirim git = new t_indirim();
            git.Show();
        }

        private void kATEGORİYEGÖREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k_indirim git = new k_indirim();
            git.Show();
        }

        private void lİSTELEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urunler git = new urunler();
            git.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void sİPARİŞLERToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            siparisler git = new siparisler();
            git.MdiParent = this;
            git.Show();
        }
    }
}
