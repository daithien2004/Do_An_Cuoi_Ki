namespace DoAnLTW.FKSan
{
    partial class UCDeXuat
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCDeXuat));
            this.lblSoLuot = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.pic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblLuotDanhGia = new System.Windows.Forms.Label();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.guna2ShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSoLuot
            // 
            this.lblSoLuot.AutoSize = true;
            this.lblSoLuot.BackColor = System.Drawing.Color.White;
            this.lblSoLuot.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 10.2F);
            this.lblSoLuot.ForeColor = System.Drawing.Color.Black;
            this.lblSoLuot.Location = new System.Drawing.Point(9, 36);
            this.lblSoLuot.Name = "lblSoLuot";
            this.lblSoLuot.Size = new System.Drawing.Size(101, 21);
            this.lblSoLuot.TabIndex = 151;
            this.lblSoLuot.Text = "1.826 chỗ nghỉ";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.BackColor = System.Drawing.Color.White;
            this.lblTen.Font = new System.Drawing.Font("UTM Cooper Black", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.ForeColor = System.Drawing.Color.Black;
            this.lblTen.Location = new System.Drawing.Point(8, 7);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(91, 23);
            this.lblTen.TabIndex = 150;
            this.lblTen.Text = "Vũng Tàu";
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 10;
            this.gunaElipse1.TargetControl = this;
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.White;
            this.pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.ImageRotate = 0F;
            this.pic.Location = new System.Drawing.Point(0, 0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(257, 204);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 6;
            this.pic.TabStop = false;
            // 
            // lblLuotDanhGia
            // 
            this.lblLuotDanhGia.AutoSize = true;
            this.lblLuotDanhGia.BackColor = System.Drawing.Color.White;
            this.lblLuotDanhGia.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 10.2F);
            this.lblLuotDanhGia.ForeColor = System.Drawing.Color.Black;
            this.lblLuotDanhGia.Location = new System.Drawing.Point(9, 60);
            this.lblLuotDanhGia.Name = "lblLuotDanhGia";
            this.lblLuotDanhGia.Size = new System.Drawing.Size(21, 21);
            this.lblLuotDanhGia.TabIndex = 152;
            this.lblLuotDanhGia.Text = "✓";
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.lblTen);
            this.guna2ShadowPanel1.Controls.Add(this.lblLuotDanhGia);
            this.guna2ShadowPanel1.Controls.Add(this.lblSoLuot);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 204);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 5;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowDepth = 0;
            this.guna2ShadowPanel1.ShadowShift = 0;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(257, 86);
            this.guna2ShadowPanel1.TabIndex = 153;
            // 
            // UCDeXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pic);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "UCDeXuat";
            this.Size = new System.Drawing.Size(257, 290);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label lblSoLuot;
        public System.Windows.Forms.Label lblTen;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        public Guna.UI2.WinForms.Guna2PictureBox pic;
        public System.Windows.Forms.Label lblLuotDanhGia;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
    }
}
