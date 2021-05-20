using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace oto_kiralama_otomasyonu
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void menu_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            arac_islemleri arac = new arac_islemleri();
            arac.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            musteri_islemleri arac = new musteri_islemleri();
            arac.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Arac_Kiralama arac = new Arac_Kiralama();
            arac.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            arac_Teslim arac = new arac_Teslim();
            arac.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            arac_satis satis = new arac_satis();
            satis.Show();
            this.Hide();
        }
    }
}
