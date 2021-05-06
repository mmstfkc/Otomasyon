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
    public partial class musteri_ol : Form
    {
        public musteri_ol()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost\\SQLExpress; initial Catalog=oto_kiralama; Integrated Security=true;");
        DataTable dt = new DataTable();

        private void musteri_ol_Load(object sender, EventArgs e)
        {

        }

        public void ekle()
        {
            if (maskedTextBox1.Text.Length != 11)
            {
                MessageBox.Show("hata!!! TC numarası giriş Formatınız Yanlıştır.");
            }
            else
            {
                try
                {
                    SqlCommand komut = new SqlCommand("insert into musteri(tc,adi_soyadi,cinsiyet,telefon,dogum_tarihi,ehliyet_no,sifre,gizli_soru,yaniti) values('" + maskedTextBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + comboBox1.Text + "','" + textBox9.Text + "')", baglanti);
                    //
                    // 
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Müşteri Olma İşleminiz Başarılı Anasayfaya Yönlendiriliyorsunuz ");
                    baglanti.Close();
                    girisform frm = new girisform();
                    frm.Show();
                    this.Hide();

                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);
                }

            }
          

            //

        }
        public void temizle()
        {
            maskedTextBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ekle();
            temizle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
