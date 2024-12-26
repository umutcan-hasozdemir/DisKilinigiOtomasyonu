using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;    

namespace DisKilinigiOtomasyonu
{
    public partial class Randevu : Form
    {
        public string KullaniciRol { get; set; }

        public Randevu()
        {
            InitializeComponent();
        }
        ConnectionString MyCon = new ConnectionString();
        private void fillHasta()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select HAd from HastaTbl", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HAd", typeof(string));
            dt.Load(rdr);
            RadCb.ValueMember = "HAd";
            RadCb.DataSource = dt;
            baglanti.Close();
        }

        private void fillTedavi()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select TAd from TedaviTbl", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TAd", typeof(string));
            dt.Load(rdr);
            RtedaviCb.ValueMember = "TAd";
            RtedaviCb.DataSource = dt;
            baglanti.Close();
        }
        private bool RandevuVarMi(string tarih, string saat)
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            string query = "SELECT COUNT(*) FROM RandevuTbl WHERE RTarih = @RTarih AND RSaat = @RSaat";
            SqlCommand komut = new SqlCommand(query, baglanti);
            komut.Parameters.AddWithValue("@RTarih", tarih);
            komut.Parameters.AddWithValue("@RSaat", saat);

            int count = Convert.ToInt32(komut.ExecuteScalar());
            baglanti.Close();

            return count > 0; // Eğer aynı tarih ve saat varsa true döner
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Randevu_Load(object sender, EventArgs e)
        {
            fillHasta();
            fillTedavi();
            uyeler();
            reset();
        }
        void uyeler()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from RandevuTbl";
            DataSet ds = hs.ShowHasta(query);
            RandevuDgv.DataSource = ds.Tables[0];
        }
        void filter()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from RandevuTbl where Hasta like '%" + araTb.Text + "%'";
            DataSet ds = hs.ShowHasta(query);
            RandevuDgv.DataSource = ds.Tables[0];
        }
        void reset()
        {
            RadCb.SelectedIndex = -1;
            RtedaviCb.SelectedIndex = -1;
            Rtarih.Text = "";
            SaatCb.Text = "";
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {

            string tarih = Rtarih.Text;
            string saat = SaatCb.Text;

            // Aynı tarih ve saat için randevu kontrolü
            if (RandevuVarMi(tarih, saat))
            {
                MessageBox.Show("Bu saat için zaten bir randevu var. Lütfen başka bir saat seçin.");
                return;
            }

            string query = "INSERT INTO RandevuTbl (Hasta, Tedavi, RTarih, RSaat) VALUES ('"
                            + RadCb.SelectedValue.ToString() + "','"
                            + RtedaviCb.SelectedValue.ToString() + "','"
                            + tarih + "','"
                            + saat + "')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Randevu başarılı bir şekilde eklendi");
                uyeler();
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int key = 0;
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Hastalar hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Güncellenecek Randevuyu Seçiniz");
                return;
            }

            string tarih = Rtarih.Text;
            string saat = SaatCb.Text;

            // Aynı tarih ve saat için randevu kontrolü
            if (RandevuVarMi(tarih, saat))
            {
                MessageBox.Show("Bu saat için zaten bir randevu var. Lütfen başka bir saat seçin.");
                return;
            }

            try
            {
                string query = "UPDATE RandevuTbl SET Hasta = '" + RadCb.SelectedValue.ToString() +
                               "', Tedavi = '" + RtedaviCb.SelectedValue.ToString() +
                               "', RTarih = '" + tarih +
                               "', RSaat = '" + saat +
                               "' WHERE RId = " + key + ";";
                hs.HastaSil(query);
                MessageBox.Show("Randevu başarılı bir şekilde güncellendi");
                uyeler();
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void RandevuDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RadCb.SelectedValue = RandevuDgv.SelectedRows[0].Cells[1].Value.ToString();
            RtedaviCb.SelectedValue = RandevuDgv.SelectedRows[0].Cells[2].Value.ToString();
            Rtarih.Text = RandevuDgv.SelectedRows[0].Cells[3].Value.ToString();
            SaatCb.Text = RandevuDgv.SelectedRows[0].Cells[4].Value.ToString();
            if (RadCb.SelectedIndex == -1)
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(RandevuDgv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Hastalar hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Randevuyu Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete from RandevuTbl where RId=" + key + "";
                    hs.HastaSil(query);
                    MessageBox.Show("Randevu başarılı bir şekilde silindi");
                    uyeler();
                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                };
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }


        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void hastabtn_Click(object sender, EventArgs e)
        {
            Hasta hastaForm = new Hasta(); // "Hasta" formunu aç
            hastaForm.Show(); // Hasta formunu göster
            this.Hide(); // Mevcut formu gizle
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            // Tedavi sayfasına erişim kontrolü
            if (KullaniciRol == "Sekreter")
            {
                MessageBox.Show("Bu sayfaya erişim izniniz yok!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Eğer kullanıcı sekreter ise işlem burada durur
                this.Close();
            }
            // Doktor ise Tedavi sayfasını aç
            Tedavi tdv = new Tedavi();
            tdv.Show();
            this.Hide(); // Ana sayfayı gizle



        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            Receteler recetelerForm = new Receteler(); // "Reçeteler" formunu aç
            recetelerForm.Show(); // Reçeteler formunu göster
            this.Hide(); // Mevcut formu gizle
        }

        private void RadCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
