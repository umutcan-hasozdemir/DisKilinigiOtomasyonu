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
    public partial class AnaSayfa : Form
    {
        public string KullaniciRol { get; set; }
        public AnaSayfa()
        {
            InitializeComponent();
        }
        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            // Rol kontrolü yaparak tedavi butonunu devre dışı bırak veya gizle
            if (KullaniciRol  == "Sekreter")
            {
                tedaviButton.Enabled = false; // Butonu devre dışı bırak
                tedaviButton.Visible = false; // İsterseniz tamamen gizleyebilirsiniz
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Randevu rnd = new Randevu();
            rnd.Show();
            this.Hide();
        }

        private void hastabtn_Click(object sender, EventArgs e)
        {
            Hasta hst = new Hasta();
            hst.Show();
            this.Hide();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // Tedavi sayfasına erişim kontrolü
            if (KullaniciRol == "Sekreter")
            {
                MessageBox.Show("Bu sayfaya erişim izniniz yok!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Eğer kullanıcı sekreter ise işlem burada durur
            }

            // Eğer kullanıcı sekreter değilse, Tedavi formunu aç
            Tedavi tdv = new Tedavi();
            tdv.Show();
            this.Hide(); // Ana sayfayı gizle
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Receteler rct = new Receteler();
            rct.Show();
            this.Hide();
        }
    }
}
