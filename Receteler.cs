using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static Guna.UI2.Native.WinApi;

namespace DisKilinigiOtomasyonu
{
    public partial class Receteler : Form
    {
        public string KullaniciRol { get; set; }
        public Receteler()
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
            hastaadtb.ValueMember = "HAd";
            hastaadtb.DataSource = dt;
            baglanti.Close();
        }
        private void fillTedavi()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from RandevuTbl where Hasta='" + hastaadtb.SelectedValue.ToString() + "'", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                tadtxt.Text = dr["Tedavi"].ToString();
            }
            baglanti.Close();
        }
        private void fillPrice()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TedaviTbl where TAd='" + tadtxt.Text + "'", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                tutartb.Text = dr["TUcret"].ToString();
            }
            baglanti.Close();
        }

        private void Receteler_Load(object sender, EventArgs e)
        {
            fillHasta();
            uyeler();
            reset();
        }

        private void guna2ComboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fillTedavi();
        }

        void uyeler()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from ReceteTbl";
            DataSet ds = hs.ShowHasta(query);
            ReceteDGV.DataSource = ds.Tables[0];
        }

        void filter()
        {
            Hastalar hs = new Hastalar();
            string query = "select * from ReceteTbl where HasId like '%" + AraTb.Text + "%'";
            DataSet ds = hs.ShowHasta(query);
            ReceteDGV.DataSource = ds.Tables[0];
        }

        void reset()
        {
            hastaadtb.SelectedItem = "";
            tutartb.Text = "";
            ilaclartb.Text = "";
            miktartb.Text = "";
            tadtxt.Text = "";

        }

        private void label1_Click(object sender, EventArgs e)
        {
            AnaSayfa ana = new AnaSayfa();
            ana.Show();
            this.Hide();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string query = "insert into ReceteTbl values('" + hastaadtb.SelectedValue.ToString() + "','" + tadtxt.Text + "'," + tutartb.Text + ",'" + ilaclartb.Text + "'," + miktartb.Text + ")";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Reçete başarılı bir şekilde eklendi");
                uyeler();
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tutartb_TextChanged(object sender, EventArgs e)
        {
            fillPrice();
        }

        private void tadtxt_TextChanged(object sender, EventArgs e)
        {
            fillPrice();
        }
        int key = 0;
        private void ReceteDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hastaadtb.Text = ReceteDGV.SelectedRows[0].Cells[1].Value.ToString();
            tadtxt.Text = ReceteDGV.SelectedRows[0].Cells[2].Value.ToString();
            tutartb.Text = ReceteDGV.SelectedRows[0].Cells[3].Value.ToString();
            ilaclartb.Text = ReceteDGV.SelectedRows[0].Cells[4].Value.ToString();
            miktartb.Text = ReceteDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (tadtxt.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ReceteDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Hastalar hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Reçeteyi Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete from ReceteTbl where RecId=" + key + "";
                    hs.HastaSil(query);
                    MessageBox.Show("Reçete başarılı bir şekilde silindi");
                    uyeler();
                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                };
            }
        }

        private void AraTb_TextChanged(object sender, EventArgs e)
        {
            filter();
        }
        Bitmap bitmap;
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            int height = ReceteDGV.Height;
            ReceteDGV.Height = ReceteDGV.RowCount * ReceteDGV.RowTemplate.Height * 2;
            Bitmap bmp = new Bitmap(ReceteDGV.Width, ReceteDGV.Height);
            ReceteDGV.DrawToBitmap(bmp, new Rectangle(0, 10, ReceteDGV.Width, ReceteDGV.Height));
            ReceteDGV.Height = height;
            printPreviewDialog1.ShowDialog();


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void hastabtn_Click(object sender, EventArgs e)
        {

            Hasta hastaForm = new Hasta(); // "Hasta" formunu aç
            hastaForm.Show(); // Hasta formunu göster
            this.Hide(); // Mevcut formu gizle

        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            Randevu randevuForm = new Randevu(); // "Randevu" formunu aç
            randevuForm.Show(); // Randevu formunu göster
            this.Hide(); // Mevcut formu gizle
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
