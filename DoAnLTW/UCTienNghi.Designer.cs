namespace DoAnLTW
{
    partial class UCTienNghi
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
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.lblTienNghi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // pic1
            // 
            this.pic1.BackColor = System.Drawing.Color.White;
            this.pic1.Location = new System.Drawing.Point(3, 4);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(40, 40);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic1.TabIndex = 108;
            this.pic1.TabStop = false;
            // 
            // lblTienNghi
            // 
            this.lblTienNghi.AllowDrop = true;
            this.lblTienNghi.AutoSize = true;
            this.lblTienNghi.BackColor = System.Drawing.Color.White;
            this.lblTienNghi.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienNghi.ForeColor = System.Drawing.Color.DimGray;
            this.lblTienNghi.Location = new System.Drawing.Point(55, 15);
            this.lblTienNghi.Name = "lblTienNghi";
            this.lblTienNghi.Size = new System.Drawing.Size(75, 19);
            this.lblTienNghi.TabIndex = 109;
            this.lblTienNghi.Text = "tiện nghi";
            // 
            // UCTienNghi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTienNghi);
            this.Controls.Add(this.pic1);
            this.Name = "UCTienNghi";
            this.Size = new System.Drawing.Size(174, 48);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pic1;
        public System.Windows.Forms.Label lblTienNghi;
    }
}
