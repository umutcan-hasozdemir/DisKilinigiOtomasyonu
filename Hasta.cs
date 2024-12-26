using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisKilinigiOtomasyonu
{
    public partial class Hasta : Form
    {
        public string KullaniciRol { get; set; }
        public Hasta()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void uyeler()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from HastaTbl";
            DataSet ds = hs.ShowHasta(query);
            HastaDGV.DataSource = ds.Tables[0];
        }

        void filter()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from HastaTbl where HAd like '%" + AraTb.Text + "%'";
            DataSet ds = hs.ShowHasta(query);
            HastaDGV.DataSource = ds.Tables[0];
        }
        void reset()
        {
            HAdSoyadTb.Text = "";
            HTelefonTb.Text = "";
            HAdresTb.Text = "";
            HDogumTarih.Text = "";
            HCinsiyetCb.SelectedItem = 0;
            HAlerjiTb.Text = "";
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string query = "insert into HastaTbl values('" + HAdSoyadTb.Text + "','" + HTelefonTb.Text + "','" + HAdresTb.Text + "','" + HDogumTarih.Value.Date + "','" + HCinsiyetCb.SelectedItem.ToString() + "','" + HAlerjiTb.Text + "')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Hatsa başarılı bir şekilde eklendi");
                uyeler();
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Hasta_Load(object sender, EventArgs e)
        {
            uyeler();
            reset();
        }
        int key = 0;
        private void HastaDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HAdSoyadTb.Text = HastaDGV.SelectedRows[0].Cells[1].Value.ToString();
            HTelefonTb.Text = HastaDGV.SelectedRows[0].Cells[2].Value.ToString();
            HAdresTb.Text = HastaDGV.SelectedRows[0].Cells[3].Value.ToString();
            HDogumTarih.Text = HastaDGV.SelectedRows[0].Cells[4].Value.ToString();
            HCinsiyetCb.SelectedItem = HastaDGV.SelectedRows[0].Cells[5].Value.ToString();
            HAlerjiTb.Text = HastaDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (HAdSoyadTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(HastaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Hastalar hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Hastayı Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete from HastaTbl where HId=" + key + "";
                    hs.HastaSil(query);
                    MessageBox.Show("Hasta başarılı bir şekilde silindi");
                    uyeler();
                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                };
            }

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Hastalar hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Hastayı Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Update HastaTbl set HAd='" + HAdSoyadTb.Text + "', HTelefon='" + HTelefonTb.Text + "', HAdres='" + HAdresTb.Text + "', HDogumT='" + HDogumTarih.Text + "', " +
                        "HCinsiyet='" + HCinsiyetCb.SelectedItem.ToString() + "', HAlerji='" + HAlerjiTb.Text + "' where HId=" + key + ";";
                    hs.HastaSil(query);
                    MessageBox.Show("Hasta başarılı bir şekilde Güncellendi");
                    uyeler();
                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                };
            }
        }

        private void HCinsiyetCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            AnaSayfa ana = new AnaSayfa();
            ana.Show();
            this.Hide();
        }

        private void AraTb_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void hastabtn_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            Randevu randevuForm = new Randevu(); // "Randevu" formunu aç
            randevuForm.Show(); // Randevu formunu göster
            this.Hide(); // Mevcut formu gizle
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
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

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            Receteler recetelerForm = new Receteler(); // "Reçeteler" formunu aç
            recetelerForm.Show(); // Reçeteler formunu göster
            this.Hide(); // Mevcut formu gizle
        }
    }
}
