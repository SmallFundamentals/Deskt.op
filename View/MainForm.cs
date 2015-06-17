using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MaterialSkin;
using MaterialSkin.Controls;

using Deskt.op.Util;

namespace Deskt.op.View
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly SplashBaseWallpaperManager wallpaperManager;
        private delegate void AsyncSetWallpaper();
        private delegate void AsyncSetURI();
        private AsyncSetWallpaper delegateSetWallPaper;
        private AsyncSetURI delegateSetURI;

        private Timer timer;
        private Uri uri;

        public MainForm()
        {
            // API Call
            wallpaperManager = new SplashBaseWallpaperManager();
            delegateSetWallPaper = this.SetWallpaper;
            delegateSetURI = this.SetURI;
            delegateSetURI.BeginInvoke(null, null);

            // Form component setup
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
            this.Resize += MainForm_Resize;

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
            DesktopWallpaper.Set(uri, DesktopWallpaper.Style.Fill);
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            delegateSetWallPaper.BeginInvoke(null, null);
            delegateSetURI.BeginInvoke(null, null);
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = (10000); // 1s
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            delegateSetWallPaper.BeginInvoke(null, null);
            delegateSetURI.BeginInvoke(null, null);
            timer.Stop(); 
        }

        /* -------- Form Manipulation -------- */

        /* Handler for closing the main form.
         * Hides application in system tray instead of exiting if close button.
         */
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
                this.notifyIcon.Visible = true;
            }
        }

        /* Handler for resizing the main form.
         * Minimizes the system tray instead of the taskbar.
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

        /* Handler for double clicking of the system tray icon.
         * Unhides the application.
         */
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
    }
}
