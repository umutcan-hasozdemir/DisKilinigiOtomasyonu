using Guna.UI2.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DisKilinigiOtomasyonu
{
    public partial class Giris : Form
    {
        // ConnectionString s�n�f� �zerinden ba�lant� alaca��z
        ConnectionString connString = new ConnectionString();

        public Giris()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form y�klendi�inde yap�lacak i�lemler
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
                // pictureBox1 t�kland���nda yap�lacak i�lemler
                MessageBox.Show("Resme t�klad�n�z!");
            

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Kullan�c� ad� i�in TextBox de�i�im i�lemleri (Gerekirse burada i�lem yapabilirsiniz)
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
          
        }
       


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // Kullan�c� ad� ve �ifre giri� kontrol�
            string kullaniciAdi = kadtxt.Text.Trim();
            string sifre = sftxt.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("L�tfen t�m alanlar� doldurunuz!", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Veri taban� ba�lant�s�n� ba�lat
                using (SqlConnection baglanti = connString.GetCon())
                {
                    baglanti.Open();

                    // SQL sorgusu ile kullan�c� kontrol�
                    string sorgu = "SELECT Rol FROM Personeller WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    komut.Parameters.AddWithValue("@Sifre", sifre);

                    SqlDataReader dr = komut.ExecuteReader();

                    if (dr.Read())
                    {
                        string rol = dr["Rol"].ToString();

                        // Kullan�c�n�n rol� ba�ar�l� �ekilde al�nd���nda
                        MessageBox.Show($"Giri� ba�ar�l�! Rol: {rol}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // AnaSayfa formuna rol� aktararak g�ster
                        AnaSayfa anaSayfa = new AnaSayfa
                        {
                            KullaniciRol = rol // Rol bilgisini aktar
                        };
                        anaSayfa.Show();
                        this.Hide(); // Giri� formunu gizle
                    }
                    else
                    {
                        // Hatal� giri�
                        MessageBox.Show("Hatal� kullan�c� ad� veya �ifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                // Hata mesaj� g�ster
                MessageBox.Show($"Bir hata olu�tu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
