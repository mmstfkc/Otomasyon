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
    public partial class Arac_Kiralama : Form
    {
        public Arac_Kiralama()
        {
            InitializeComponent();
        }
        
        private void Arac_Kiralama_Load(object sender, EventArgs e)
        {
            musteridoldur();
            uygunaracdoldur();
            doldur();
        }
        void doldur()
        {
            try
            {
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        void musteridoldur()
        {
            
        }
        void uygunaracdoldur()
        {
            
        }
       

        private void button5_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = dateTimePicker2.Value.ToShortDateString();
        }

       

   
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            

        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Parse(textBox4.Text);
                DateTime dt2 = DateTime.Parse(textBox3.Text);
                TimeSpan fark = dt - dt2;
                textBox5.Text = (fark.TotalDays * 150).ToString();

            }
            catch
            { 

                ;
            }
        }
    }
}