using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace xServer
{
    public partial class FrmLoading : Form
    {
        private IContainer components;

        private Guna2BorderlessForm guna2BorderlessForm1;

        public FrmLoading()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void FrmLoading_Load(object sender, EventArgs e)
        {
            base.StartPosition = FormStartPosition.Manual;
            int num = Screen.PrimaryScreen.WorkingArea.Width;
            int num2 = Screen.PrimaryScreen.WorkingArea.Height;
            int num3 = base.Width;
            int num4 = base.Height;
            int num5 = (num - num3) / 2;
            int num6 = (num2 - num4) / 2;
            base.Location = new Point(num5, num6);
            this.TopMost = true;
        }
    }
}
