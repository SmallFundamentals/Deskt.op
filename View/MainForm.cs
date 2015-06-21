using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using MaterialSkin;
using MaterialSkin.Controls;

using Deskt.op.Util;
using Deskt.op.Util.Interface;

namespace Deskt.op.View
{

    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly IWallpaperManager wallpaperManager;
        private delegate void AsyncSetWallpaper();
        private delegate void AsyncSetURI();
        private AsyncSetWallpaper delegateSetWallPaper;
        private AsyncSetURI delegateSetURI;
        private IAsyncResult setWallpaperResult;
        private IAsyncResult setURIResult;

        private System.Windows.Forms.Timer timer;
        private Uri uri;

        public MainForm()
        {
            // API Call
            wallpaperManager = new SplashBaseWallpaperManager();
            delegateSetWallPaper = this.SetWallpaper;
            delegateSetURI = this.SetURI;
            setURIResult = delegateSetURI.BeginInvoke(null, null);

            // Form component setup
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
            this.Resize += MainForm_Resize;
            this.userWallpaperPictureBox.Image = wallpaperManager.GetUserWallpaper();
            this.materialTabControl1.SelectedIndexChanged += materialTabControl1_SelectedIndexChanged;

            // Material component setup
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, 
                Primary.BlueGrey900, 
                Primary.BlueGrey500, 
                Accent.LightBlue200, 
                TextShade.WHITE);
        }

        private void SetURI()
        {
            uri = new Uri(wallpaperManager.GetNextRandomUrl());
        }

        private void SetWallpaper()
        {
            while (setURIResult.IsCompleted == false)
            {
                Thread.Sleep(100);
            }
            DesktopWallpaper.Set(uri, DesktopWallpaper.Style.Fill);
            this.userWallpaperPictureBox.Image = wallpaperManager.GetUserWallpaper();
        }

        /* ------------------ Form Handlers ------------------ */

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            { 
                case 0:
                    this.pictureBox1.Show();
                    break;
                default:
                    this.pictureBox1.Hide();
                    break;
            }
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = (10000); // 10s
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            setWallpaperResult = delegateSetWallPaper.BeginInvoke(null, null);
            setURIResult = delegateSetURI.BeginInvoke(null, null);
        }

        /* Handler for closing the main form. Hides application in system tray instead of exiting if close button.
         */
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // DISABLED FOR DEVELOPMENT
            return;
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
                this.notifyIcon.Visible = true;
            }
        }

        /* Handler for resizing the main form. Minimizes the system tray instead of the taskbar.
         */
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.notifyIcon.Visible = true;
                // this.notifyIcon.ShowBalloonTip(500);
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                this.notifyIcon.Visible = false;
            }
        }

        /* Handler for double clicking of the system tray icon. Unhides the application.
         */
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        /* Handler for save wallpaper icon
         */
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.Filter = "All Files (*.*)|*.*|Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.RestoreDirectory = true;
            
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                wallpaperManager.GetUserWallpaper().Save(this.saveFileDialog1.FileName, ImageFormat.Bmp);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            setWallpaperResult = delegateSetWallPaper.BeginInvoke(null, null);
            setURIResult = delegateSetURI.BeginInvoke(null, null);
        }
    }
}
