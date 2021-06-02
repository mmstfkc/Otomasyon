using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace oto_kiralama_otomasyonu
{
    public partial class arac_Teslim : Form
    {
        
        public arac_Teslim()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }
        void uygunaracdoldur()
        {
            comboBox1.Items.Clear();
            
        }

        

        private void arac_Teslim_Load(object sender, EventArgs e)
        {
            uygunaracdoldur();
        }
    }
}
