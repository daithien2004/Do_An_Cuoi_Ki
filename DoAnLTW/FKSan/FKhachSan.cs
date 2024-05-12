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
using Bunifu.UI.WinForms;
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
        FThongTinKS fchildglobal = new FThongTinKS();
        private void FKhachSan_Load(object sender, EventArgs e)
        {
            OpenChildForm(fchildglobal);
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

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            FTrangChu ftrangChu = new FTrangChu();
            ftrangChu.Show();
            this.Hide();
        }

        private void btnThongTinChuKhach_Click(object sender, EventArgs e)
        {
            if (fchildglobal.bunifuPages1.SelectedIndex == 1)
            {
                fchildglobal.bunifuPages1.SetPage(0);

            }
            else
            {
                fchildglobal.bunifuPages1.SetPage(fchildglobal.bunifuPages1.SelectedIndex + 1);

            }
        }
        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            FTrangChu ftrangChu = new FTrangChu();
            ftrangChu.Show();
            this.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            FTrangChu ftrangChu = new FTrangChu();
            ftrangChu.Show();
            this.Hide();
        }
        private void btnVeTrai_Click(object sender, EventArgs e)
        {
            if (fchildglobal.bunifuPages1.SelectedIndex == 0)
            {
                fchildglobal.bunifuPages1.SetPage(0);

            }
            else
            {
                fchildglobal.bunifuPages1.SetPage(fchildglobal.bunifuPages1.SelectedIndex - 1);

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FTrangChu ftrangChu = new FTrangChu();
            ftrangChu.Show();
            this.Hide();
        }
    }
}
