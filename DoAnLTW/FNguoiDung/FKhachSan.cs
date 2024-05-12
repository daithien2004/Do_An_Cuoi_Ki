using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DoAnLTW
{
    public partial class FKhachSan : Form
    {
        Form currentChildForm;
        bool isCurrentChildForm = false;
        public FKhachSan()
        {
            InitializeComponent();
        }
        public void OpenChildForm(Form childForm)
        {
            if (isCurrentChildForm)
            {
                currentChildForm.Close();
                isCurrentChildForm = false;
            }
            currentChildForm = childForm;
            currentChildForm.TopLevel = false;
            currentChildForm.Dock = DockStyle.Fill;
            gunaElipsePanel2.Controls.Add(currentChildForm);
            currentChildForm.BringToFront();
            currentChildForm.Show();
            isCurrentChildForm = true;
        }

        private void FKhachSan_Load(object sender, EventArgs e)
        {
            FThongTinKS fchild = new FThongTinKS();
            OpenChildForm(fchild);
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            FDatPhongKS fchild = new FDatPhongKS();
            OpenChildForm(fchild);
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            FThongTinKS fchild = new FThongTinKS();
            OpenChildForm(fchild);
        }

        private void gunaAdvenceButton1_Click_1(object sender, EventArgs e)
        {
            FThongTinKS fchild = new FThongTinKS();
            OpenChildForm(fchild);
        }

        private void gunaAdvenceButton1_Click_2(object sender, EventArgs e)
        {
            FThongTinKS fchild = new FThongTinKS();
            OpenChildForm(fchild);
        }

        private void gunaAdvenceButton2_Click_1(object sender, EventArgs e)
        {
            FDatPhongKS fchild = new FDatPhongKS();
            OpenChildForm(fchild);
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            FTrangChu ftrangChu = new FTrangChu();
            ftrangChu.Show();
            this.Hide();
        }
    }
}
