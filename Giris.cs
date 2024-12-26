using Guna.UI2.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DisKilinigiOtomasyonu
{
    public partial class Giris : Form
    {
        // ConnectionString sýnýfý üzerinden baðlantý alacaðýz
        ConnectionString connString = new ConnectionString();

        public Giris()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form yüklendiðinde yapýlacak iþlemler
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
                // pictureBox1 týklandýðýnda yapýlacak iþlemler
                MessageBox.Show("Resme týkladýnýz!");
            

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Kullanýcý adý için TextBox deðiþim iþlemleri (Gerekirse burada iþlem yapabilirsiniz)
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
          
        }
       


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // Kullanýcý adý ve þifre giriþ kontrolü
            string kullaniciAdi = kadtxt.Text.Trim();
            string sifre = sftxt.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen tüm alanlarý doldurunuz!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Veri tabaný baðlantýsýný baþlat
                using (SqlConnection baglanti = connString.GetCon())
                {
                    baglanti.Open();

                    // SQL sorgusu ile kullanýcý kontrolü
                    string sorgu = "SELECT Rol FROM Personeller WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    komut.Parameters.AddWithValue("@Sifre", sifre);

                    SqlDataReader dr = komut.ExecuteReader();

                    if (dr.Read())
                    {
                        string rol = dr["Rol"].ToString();

                        // Kullanýcýnýn rolü baþarýlý þekilde alýndýðýnda
                        MessageBox.Show($"Giriþ baþarýlý! Rol: {rol}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // AnaSayfa formuna rolü aktararak göster
                        AnaSayfa anaSayfa = new AnaSayfa
                        {
                            KullaniciRol = rol // Rol bilgisini aktar
                        };
                        anaSayfa.Show();
                        this.Hide(); // Giriþ formunu gizle
                    }
                    else
                    {
                        // Hatalý giriþ
                        MessageBox.Show("Hatalý kullanýcý adý veya þifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                // Hata mesajý göster
                MessageBox.Show($"Bir hata oluþtu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
