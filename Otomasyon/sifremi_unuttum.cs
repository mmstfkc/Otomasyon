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
    public partial class sifremi_unuttum : Form
    {
        public sifremi_unuttum()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost\\SQLExpress; initial Catalog=oto_kiralama; Integrated Security=true;");
        DataTable dt = new DataTable();

        private void button2_Click(object sender, EventArgs e)
        {
            gizlisoru();
        }
        public void gizlisoru()
        {

            SqlCommand komut = new SqlCommand("select * from musteri where tc='" + textBox1.Text + "'", baglanti);
            //mysql komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            baglanti.Open();//bağlantıyı açdık

            SqlDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {
                panel1.Visible = false;
                textBox2.Text = oku["gizli_soru"].ToString();
                baglanti.Close();//bağlantıyı kapar
               

            }
            else
            {
                MessageBox.Show("Kullanıcı Adınız Yada Şifreniz Yanlış Yazılmıştır");//hayır veri okuyamadıysa uyarı verir
                textBox1.Text = "";
                textBox2.Text = "";
                //verileri temizler
            }
        }
        public void sifreyial()
        {

        }


            private void button1_Click(object sender, EventArgs e)
        {

            
            SqlConnection baglanti = new SqlConnection("Data Source=localhost\\SQLExpress; initial Catalog=oto_kiralama; Integrated Security=true");
            //mysql bağlantıyı sağladık
            SqlCommand komut = new SqlCommand("select * from musteri where tc='" + textBox1.Text + "' and yaniti ='" + textBox3.Text + "'", baglanti);
            //mysql komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            baglanti.Open();//bağlantıyı açdık

            SqlDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {
                panel2.Visible = false;
                textBox4.Text = oku["sifre"].ToString();

            }
            else
            {
                MessageBox.Show("Hatalı Bilgiler");//hayır veri okuyamadıysa uyarı verir
               
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox4.Text);
            MessageBox.Show("Kopyalama İşlemi Başarılı");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            girisform giris = new girisform();
            giris.Show();
            this.Hide();
        }
    }
}
