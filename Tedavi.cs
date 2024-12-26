using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace DisKilinigiOtomasyonu
{
    public partial class Tedavi : Form
    {
        public Tedavi()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, EventArgs e)

        {
            string query = "insert into TedaviTbl values('" + Tedavitb.Text + "','" + Tutartb.Text + "','" + Acıklamatb.Text + "')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Tedavi başarılı bir şekilde eklendi");
                uyeler();
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int key;
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Hastalar hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Güncellenecek Tedaviyi Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Update TedaviTbl set TAd='" + Tedavitb.Text + "', TUcret='" + Tutartb.Text + "', TAcıklama='" + Acıklamatb.Text + "' where TId=" + key + ";";
                    hs.HastaSil(query);
                    MessageBox.Show("Tedavi başarılı bir şekilde Güncellendi");
                    uyeler();
                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                };
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Hastalar hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Tedaviyi Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete from TedaviTbl where TId=" + key + "";
                    hs.HastaSil(query);
                    MessageBox.Show("Tedavi başarılı bir şekilde silindi");
                    uyeler();
                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                };
            }
        }

        void uyeler()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from TedaviTbl";
            DataSet ds = hs.ShowHasta(query);
            TedaviDGV.DataSource = ds.Tables[0];
        }
        void filter()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from TedaviTbl where TAd like '%" + ARATB.Text + "%'";
            DataSet ds = hs.ShowHasta(query);
            TedaviDGV.DataSource = ds.Tables[0];
        }

        void reset()
        {
            Tedavitb.Text = "";
            Tutartb.Text = "";
            Acıklamatb.Text = "";

        }
        private void Tedavi_Load(object sender, EventArgs e)
        {
            uyeler();
            reset();
        }

        private void TedaviDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Tedavitb.Text = TedaviDGV.SelectedRows[0].Cells[1].Value.ToString();
            Tutartb.Text = TedaviDGV.SelectedRows[0].Cells[2].Value.ToString();
            Acıklamatb.Text = TedaviDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (Tedavitb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TedaviDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AnaSayfa ana = new AnaSayfa();
            ana.Show();
            this.Hide();
        }

        private void TedaviDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ARATB_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void hastabtn_Click(object sender, EventArgs e)
        {
            Hasta hastaForm = new Hasta(); // "Hasta" formunu aç
            hastaForm.Show(); // Hasta formunu göster
            this.Hide(); // Mevcut formu gizle
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            Randevu randevuForm = new Randevu(); // "Randevu" formunu aç
            randevuForm.Show(); // Randevu formunu göster
            this.Hide(); // Mevcut formu gizle
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            Receteler recetelerForm = new Receteler(); // "Reçeteler" formunu aç
            recetelerForm.Show(); // Reçeteler formunu göster
            this.Hide(); // Mevcut formu gizle
        }

        private void Tedavitb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
