namespace DoAnLTW
{
    partial class FDanhGia
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pbNguoiDung = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtDanhGia = new Bunifu.UI.WinForms.BunifuRating();
            this.txtMoTa = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bunifuShapes4 = new Bunifu.UI.WinForms.BunifuShapes();
            this.dtNgayDanhGia = new Guna.UI.WinForms.GunaDateTimePicker();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbNguoiDung)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.IconColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(347, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 50);
            this.btnClose.TabIndex = 0;
            // 
            // pbNguoiDung
            // 
            this.pbNguoiDung.Image = global::DoAnLTW.Properties.Resources.profile;
            this.pbNguoiDung.ImageRotate = 0F;
            this.pbNguoiDung.Location = new System.Drawing.Point(30, 45);
            this.pbNguoiDung.Margin = new System.Windows.Forms.Padding(4);
            this.pbNguoiDung.Name = "pbNguoiDung";
            this.pbNguoiDung.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbNguoiDung.Size = new System.Drawing.Size(77, 66);
            this.pbNguoiDung.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNguoiDung.TabIndex = 1;
            this.pbNguoiDung.TabStop = false;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Location = new System.Drawing.Point(132, 77);
            this.lblDiaChi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(78, 19);
            this.lblDiaChi.TabIndex = 2;
            this.lblDiaChi.Text = "Bình Định";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.Location = new System.Drawing.Point(132, 51);
            this.lblTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(105, 19);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Nguyễn Văn A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày đánh giá : ";
            // 
            // rtDanhGia
            // 
            this.rtDanhGia.BackColor = System.Drawing.Color.Transparent;
            this.rtDanhGia.DisabledEmptyFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.rtDanhGia.DisabledRatedFillColor = System.Drawing.Color.DarkGray;
            this.rtDanhGia.EmptyBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.rtDanhGia.EmptyFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.rtDanhGia.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.rtDanhGia.HoverFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.rtDanhGia.InnerRadius = 2F;
            this.rtDanhGia.Location = new System.Drawing.Point(132, 99);
            this.rtDanhGia.Name = "rtDanhGia";
            this.rtDanhGia.OuterRadius = 10F;
            this.rtDanhGia.RatedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.rtDanhGia.RatedFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.rtDanhGia.ReadOnly = false;
            this.rtDanhGia.RightClickToClear = true;
            this.rtDanhGia.Size = new System.Drawing.Size(121, 22);
            this.rtDanhGia.TabIndex = 3;
            this.rtDanhGia.Text = "bunifuRating1";
            this.rtDanhGia.Value = 2;
            // 
            // txtMoTa
            // 
            this.txtMoTa.AcceptsReturn = true;
            this.txtMoTa.BackColor = System.Drawing.Color.White;
            this.txtMoTa.BorderColor = System.Drawing.Color.Black;
            this.txtMoTa.BorderRadius = 10;
            this.txtMoTa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMoTa.DefaultText = "";
            this.txtMoTa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMoTa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMoTa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMoTa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMoTa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMoTa.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.txtMoTa.ForeColor = System.Drawing.Color.Black;
            this.txtMoTa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMoTa.Location = new System.Drawing.Point(30, 198);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.PasswordChar = '\0';
            this.txtMoTa.PlaceholderText = "";
            this.txtMoTa.SelectedText = "";
            this.txtMoTa.Size = new System.Drawing.Size(348, 149);
            this.txtMoTa.TabIndex = 146;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.label5.Location = new System.Drawing.Point(26, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 144;
            this.label5.Text = "Đánh giá";
            // 
            // bunifuShapes4
            // 
            this.bunifuShapes4.Angle = 0F;
            this.bunifuShapes4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuShapes4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.bunifuShapes4.BorderThickness = 2;
            this.bunifuShapes4.FillColor = System.Drawing.Color.Black;
            this.bunifuShapes4.FillShape = true;
            this.bunifuShapes4.Location = new System.Drawing.Point(30, 178);
            this.bunifuShapes4.Name = "bunifuShapes4";
            this.bunifuShapes4.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Line;
            this.bunifuShapes4.Sides = 5;
            this.bunifuShapes4.Size = new System.Drawing.Size(348, 23);
            this.bunifuShapes4.TabIndex = 145;
            this.bunifuShapes4.Text = "bunifuShapes4";
            // 
            // dtNgayDanhGia
            // 
            this.dtNgayDanhGia.BaseColor = System.Drawing.Color.White;
            this.dtNgayDanhGia.BorderColor = System.Drawing.Color.Silver;
            this.dtNgayDanhGia.CustomFormat = null;
            this.dtNgayDanhGia.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtNgayDanhGia.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtNgayDanhGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtNgayDanhGia.ForeColor = System.Drawing.Color.Black;
            this.dtNgayDanhGia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayDanhGia.Location = new System.Drawing.Point(153, 131);
            this.dtNgayDanhGia.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtNgayDanhGia.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtNgayDanhGia.Name = "dtNgayDanhGia";
            this.dtNgayDanhGia.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtNgayDanhGia.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtNgayDanhGia.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtNgayDanhGia.OnPressedColor = System.Drawing.Color.Black;
            this.dtNgayDanhGia.Size = new System.Drawing.Size(225, 38);
            this.dtNgayDanhGia.TabIndex = 147;
            this.dtNgayDanhGia.Text = "3/28/2024";
            this.dtNgayDanhGia.Value = new System.DateTime(2024, 3, 28, 0, 0, 0, 0);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.White;
            this.btnXacNhan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(178)))), ((int)(((byte)(182)))));
            this.btnXacNhan.BorderRadius = 5;
            this.btnXacNhan.BorderThickness = 1;
            this.btnXacNhan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXacNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXacNhan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(178)))), ((int)(((byte)(182)))));
            this.btnXacNhan.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(265, 354);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(113, 40);
            this.btnXacNhan.TabIndex = 148;
            this.btnXacNhan.Text = "ĐÁNH GIÁ";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // FDanhGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(401, 412);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.dtNgayDanhGia);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bunifuShapes4);
            this.Controls.Add(this.rtDanhGia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.pbNguoiDung);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FDanhGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FDanhGia";
            this.Load += new System.EventHandler(this.FDanhGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbNguoiDung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblDiaChi;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbNguoiDung;
        private Bunifu.UI.WinForms.BunifuRating rtDanhGia;
        private Guna.UI2.WinForms.Guna2TextBox txtMoTa;
        private System.Windows.Forms.Label label5;
        private Bunifu.UI.WinForms.BunifuShapes bunifuShapes4;
        private Guna.UI.WinForms.GunaDateTimePicker dtNgayDanhGia;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
    }
}