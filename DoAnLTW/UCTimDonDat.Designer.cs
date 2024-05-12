namespace DoAnLTW
{
    partial class UCTimDonDat
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIDDat = new System.Windows.Forms.Label();
            this.bunifuShapes1 = new Bunifu.UI.WinForms.BunifuShapes();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DoAnLTW.Properties.Resources.hotel__1_;
            this.pictureBox1.Location = new System.Drawing.Point(5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(55, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 78;
            this.label1.Text = "Mã Đơn:";
            // 
            // lblIDDat
            // 
            this.lblIDDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lblIDDat.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblIDDat.Location = new System.Drawing.Point(56, 22);
            this.lblIDDat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDDat.Name = "lblIDDat";
            this.lblIDDat.Size = new System.Drawing.Size(76, 23);
            this.lblIDDat.TabIndex = 79;
            this.lblIDDat.Text = "ID";
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
            this.bunifuShapes1.TabIndex = 80;
            this.bunifuShapes1.Text = "bunifuShapes1";
            // 
            // UCTimDonDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuShapes1);
            this.Controls.Add(this.lblIDDat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UCTimDonDat";
            this.Size = new System.Drawing.Size(229, 44);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblIDDat;
        private Bunifu.UI.WinForms.BunifuShapes bunifuShapes1;
    }
}
