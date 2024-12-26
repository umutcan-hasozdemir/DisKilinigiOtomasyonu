namespace DisKilinigiOtomasyonu
{
    partial class Giris
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            kadtxt = new Guna.UI2.WinForms.Guna2TextBox();
            sftxt = new Guna.UI2.WinForms.Guna2TextBox();
            loginbtn = new Guna.UI2.WinForms.Guna2GradientButton();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.CadetBlue;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(553, 94);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(10, 9);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(109, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bookman Old Style", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(143, 35);
            label1.Name = "label1";
            label1.Size = new Size(309, 28);
            label1.TabIndex = 1;
            label1.Text = "Diş Kliniği Otomasyonu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(77, 191);
            label2.Name = "label2";
            label2.Size = new Size(111, 19);
            label2.TabIndex = 1;
            label2.Text = "Kullanıcı Adı:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(147, 242);
            label3.Name = "label3";
            label3.Size = new Size(44, 19);
            label3.TabIndex = 1;
            label3.Text = "Şİfre:";
            // 
            // kadtxt
            // 
            kadtxt.BorderColor = Color.CadetBlue;
            kadtxt.BorderRadius = 10;
            kadtxt.BorderThickness = 3;
            kadtxt.CustomizableEdges = customizableEdges1;
            kadtxt.DefaultText = "doktor1";
            kadtxt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            kadtxt.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            kadtxt.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            kadtxt.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            kadtxt.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            kadtxt.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            kadtxt.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            kadtxt.Location = new Point(203, 187);
            kadtxt.Margin = new Padding(4);
            kadtxt.Name = "kadtxt";
            kadtxt.PasswordChar = '\0';
            kadtxt.PlaceholderText = "";
            kadtxt.SelectedText = "";
            kadtxt.ShadowDecoration.CustomizableEdges = customizableEdges2;
            kadtxt.Size = new Size(202, 26);
            kadtxt.TabIndex = 2;
            kadtxt.TextChanged += guna2TextBox1_TextChanged_1;
            // 
            // sftxt
            // 
            sftxt.BorderColor = Color.CadetBlue;
            sftxt.BorderRadius = 10;
            sftxt.BorderThickness = 3;
            sftxt.CustomizableEdges = customizableEdges3;
            sftxt.DefaultText = "12345";
            sftxt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            sftxt.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            sftxt.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            sftxt.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            sftxt.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            sftxt.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            sftxt.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            sftxt.Location = new Point(203, 238);
            sftxt.Margin = new Padding(4);
            sftxt.Name = "sftxt";
            sftxt.PasswordChar = '●';
            sftxt.PlaceholderText = "";
            sftxt.SelectedText = "";
            sftxt.ShadowDecoration.CustomizableEdges = customizableEdges4;
            sftxt.Size = new Size(202, 26);
            sftxt.TabIndex = 2;
            sftxt.UseSystemPasswordChar = true;
            sftxt.TextChanged += guna2TextBox1_TextChanged_1;
            // 
            // loginbtn
            // 
            loginbtn.BorderRadius = 10;
            loginbtn.BorderThickness = 3;
            loginbtn.CustomizableEdges = customizableEdges5;
            loginbtn.DisabledState.BorderColor = Color.DarkGray;
            loginbtn.DisabledState.CustomBorderColor = Color.DarkGray;
            loginbtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            loginbtn.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            loginbtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            loginbtn.FillColor = Color.CadetBlue;
            loginbtn.FillColor2 = Color.FromArgb(0, 64, 64);
            loginbtn.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            loginbtn.ForeColor = Color.Black;
            loginbtn.Location = new Point(203, 292);
            loginbtn.Margin = new Padding(3, 2, 3, 2);
            loginbtn.Name = "loginbtn";
            loginbtn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            loginbtn.Size = new Size(176, 42);
            loginbtn.TabIndex = 3;
            loginbtn.Text = "LOGİN";
            loginbtn.Click += guna2GradientButton1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bookman Old Style", 12F, FontStyle.Italic, GraphicsUnit.Point, 162);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(169, 118);
            label4.Name = "label4";
            label4.Size = new Size(198, 18);
            label4.TabIndex = 1;
            label4.Text = "MANİSA DENTAL KLİNİK";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(553, 372);
            Controls.Add(loginbtn);
            Controls.Add(label4);
            Controls.Add(sftxt);
            Controls.Add(kadtxt);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox kadtxt;
        private Guna.UI2.WinForms.Guna2TextBox sftxt;
        private Guna.UI2.WinForms.Guna2GradientButton loginbtn;
        private Label label4;
    }
}
