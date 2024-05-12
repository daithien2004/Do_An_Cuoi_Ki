namespace DoAnLTW
{
    partial class UCTinh
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
            this.lblTinh = new System.Windows.Forms.Label();
            this.bunifuShapes1 = new Bunifu.UI.WinForms.BunifuShapes();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTinh
            // 
            this.lblTinh.AutoSize = true;
            this.lblTinh.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblTinh.Location = new System.Drawing.Point(42, 3);
            this.lblTinh.Name = "lblTinh";
            this.lblTinh.Size = new System.Drawing.Size(33, 21);
            this.lblTinh.TabIndex = 0;
            this.lblTinh.Text = "Tỉnh";
            // 
            // bunifuShapes1
            // 
            this.bunifuShapes1.Angle = 0F;
            this.bunifuShapes1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuShapes1.BorderColor = System.Drawing.Color.Silver;
            this.bunifuShapes1.BorderThickness = 2;
            this.bunifuShapes1.FillColor = System.Drawing.Color.Transparent;
            this.bunifuShapes1.FillShape = true;
            this.bunifuShapes1.Location = new System.Drawing.Point(0, 37);
            this.bunifuShapes1.Name = "bunifuShapes1";
            this.bunifuShapes1.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Line;
            this.bunifuShapes1.Sides = 5;
            this.bunifuShapes1.Size = new System.Drawing.Size(229, 10);
            this.bunifuShapes1.TabIndex = 1;
            this.bunifuShapes1.Text = "bunifuShapes1";
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Image = global::DoAnLTW.Properties.Resources.map;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(5, 3);
            this.guna2PictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(32, 29);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 154;
            this.guna2PictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 155;
            this.label1.Text = "Vietnam";
            // 
            // UCTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.bunifuShapes1);
            this.Controls.Add(this.lblTinh);
            this.Name = "UCTinh";
            this.Size = new System.Drawing.Size(229, 44);
            this.Click += new System.EventHandler(this.UCTinh_Click);
            this.MouseLeave += new System.EventHandler(this.UCTinh_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UCTinh_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTinh;
        private Bunifu.UI.WinForms.BunifuShapes bunifuShapes1;
        public Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        public System.Windows.Forms.Label label1;
    }
}
