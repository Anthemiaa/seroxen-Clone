using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;

namespace xServer
{
    public partial class FrmLogin : Form
    {

        private bool isDragging;

        private Point lastLocation;

        private PictureBox pictureBox1;

        private PictureBox pictureBox2;

        private Guna2BorderlessForm guna2BorderlessForm1;

        private Panel panel1;

        private Guna2Button guna2Button2;

        private Guna2Button guna2Button1;

        private Guna2Button guna2Button5;

        private Guna2Button guna2Button4;

        private Guna2Button guna2Button3;

        private Guna2Button guna2Button6;

        private Label label2;

        public FrmLogin()
        {
            InitializeComponent();
            base.FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            InitializeFormAppearance();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath graphicsPath = new GraphicsPath();
            int num = 30;
            Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
            graphicsPath.AddArc(rectangle.X, rectangle.Y, num, num, 180f, 90f);
            graphicsPath.AddArc(rectangle.Right - num, rectangle.Y, num, num, 270f, 90f);
            graphicsPath.AddArc(rectangle.Right - num, rectangle.Bottom - num, num, num, 0f, 90f);
            graphicsPath.AddArc(rectangle.X, rectangle.Bottom - num, num, num, 90f, 90f);
            graphicsPath.CloseAllFigures();
            base.Region = new Region(graphicsPath);
        }
        private void InitializeFormAppearance()
        {
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            ControlBox = false;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = Size;
            MaximumSize = Size;
        }



        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastLocation = e.Location;
                Cursor = Cursors.Hand;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                base.Location = new Point(base.Location.X - lastLocation.X + e.X, base.Location.Y - lastLocation.Y + e.Y);
                Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                Cursor = Cursors.Default;
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            FrmLoading frmLoadingInstance = new FrmLoading();
            frmLoadingInstance.Show();
            base.WindowState = FormWindowState.Minimized;
            await Task.Delay(15000);
            frmLoadingInstance.Hide();
            Hide();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
