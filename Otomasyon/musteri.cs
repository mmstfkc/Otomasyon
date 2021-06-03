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
    public partial class musteri : Form
    {
        public musteri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new baglan().baglanti;
        DataTable dt = new DataTable();
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doldur();
        }
        void doldur()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                dt.Clear();
                SqlDataAdapter listele = new SqlDataAdapter("select * from arac", baglanti);
                listele.Fill(dt);
                dataGridView1.DataSource = dt;
                listele.Dispose();
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[3].Width = 77;
                dataGridView1.Columns[4].Width = 76;
                dataGridView1.Columns[5].Width = 76;
                dataGridView1.Columns[6].Width = 80;
                dataGridView1.Columns[7].Width = 80;
                baglanti.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox1.Text = "";
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        void uygunaracdoldur2()
        {
          
        
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                dt.Clear();
                SqlDataAdapter listele = new SqlDataAdapter("select * from arac where durum='" + "Uygun" + "'", baglanti);
                listele.Fill(dt);
                dataGridView1.DataSource = dt;
                listele.Dispose();
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[3].Width = 77;
                dataGridView1.Columns[4].Width = 76;
                dataGridView1.Columns[5].Width = 76;
                dataGridView1.Columns[6].Width = 80;
                dataGridView1.Columns[7].Width = 80;
                baglanti.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox1.Text = "";
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        private void musteri_Load(object sender, EventArgs e)
        {

        }
        void uygunaracdoldur()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                dt.Clear();
                SqlDataAdapter listele = new SqlDataAdapter("select * from arac where satis_durum='" + "Satışa Uygun" + "'", baglanti);
                listele.Fill(dt);
                dataGridView1.DataSource = dt;
                listele.Dispose();
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[3].Width = 77;
                dataGridView1.Columns[4].Width = 76;
                dataGridView1.Columns[5].Width = 76;
                dataGridView1.Columns[6].Width = 80;
                dataGridView1.Columns[7].Width = 80;
                baglanti.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox1.Text = "";
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            uygunaracdoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uygunaracdoldur2();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            pictureBox1.ImageLocation = Application.StartupPath + "\\images\\" + dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox2.Text= dataGridView1.CurrentRow.Cells[9].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }
    }
}
