using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace oto_kiralama_otomasyonu
{
    public partial class arac_islemleri : Form
    {
        public arac_islemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost\\SQLExpress; initial Catalog=oto_kiralama; Integrated Security=true");
        DataTable dt = new DataTable();
        string yeniyol = "";
        private void arac_islemleri_Load(object sender, EventArgs e)
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
                comboBox2.Text = "";
                comboBox3.Text = "";
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Kaydı silmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() != "")
            {
                try
                {

                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    SqlCommand sil = new SqlCommand("delete from arac where id='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglanti);
                    sil.ExecuteNonQuery();
                    MessageBox.Show("Silme İşleminiz Başarılı");
                    doldur();
                    baglanti.Close();

                }
                catch
                {

                    ;
                }
            }
    }

        private void button1_Click(object sender, EventArgs e)
        {

            DosyaAc.Filter = "Resim Dosyası |*.jpg;*.nef;*.png | Tüm Dosyalar |*.*";
            DosyaAc.ShowDialog();
            string dosyayolu = DosyaAc.FileName;
            yeniyol = Application.StartupPath + "\\images\\" + Guid.NewGuid().ToString() + ".jpg";
            File.Copy(dosyayolu, yeniyol);
             pictureBox1.ImageLocation = dosyayolu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("insert into arac(plaka,marka,model,arac_tipi,renk,yil,resim,durum,arac_durum,satis_durum) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "','" + Path.GetFileName(yeniyol)+ "','"+ "Uygun" + "','"+comboBox2.Text+"','"+comboBox3.Text+"')", baglanti);
                //
                // 
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleminiz Başarılı");
                pictureBox1.ImageLocation = "";
                baglanti.Close();

                doldur();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
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
            comboBox2.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();

            SqlDataAdapter adtr = new SqlDataAdapter("select * From arac where plaka like'%" + textBox6.Text + "%'or marka like '%" + textBox6.Text + "%'or model like '%" + textBox6.Text + "%'or arac_tipi like '%" + textBox6.Text + "%'or renk like '%" + textBox6.Text + "%'", baglanti);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            adtr.Dispose();


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 77;
            dataGridView1.Columns[4].Width = 76;
            dataGridView1.Columns[5].Width = 76;
            dataGridView1.Columns[6].Width = 80;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update arac set plaka='"+textBox1.Text+"',marka='"+textBox2.Text+"',model='"+textBox3.Text+"',arac_tipi='"+textBox4.Text+"',renk='"+comboBox1.Text+"',yil='"+textBox5.Text+"',resim='" + Path.GetFileName(yeniyol) + "' where id='"+ dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglanti);
            //
            // 
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
            doldur();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
