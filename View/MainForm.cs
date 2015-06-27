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
using Microsoft.Win32;

using MaterialSkin;
using MaterialSkin.Controls;

using Deskt.op.Util;
using Deskt.op.Util.Interface;

namespace Deskt.op.View
{

    public partial class MainForm : MaterialForm
    {
        //Startup registry key and value
        private static readonly string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private static readonly string StartupValue = "Deskt.op";
        private static readonly int PollingInterval = 1 * 60 * 60 * 1000; // 1hr in ms

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
            this.materialTabControl.SelectedIndexChanged += materialTabControl_SelectedIndexChanged;

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

            this.refreshIntervalTextField.Text = "   " + Properties.Settings.Default.fetchIntervalDays.ToString();
            this.materialCheckBox1.Checked = Properties.Settings.Default.isRunOnStartup;

            SetTimer();
        }

        /* Summary: 
         *   Set URI with next random wallpaper's url
         * 
         * Parameters:
         *   N/A
         *   
         * Return:
         *   N/A
         */
        private void SetURI()
        {
            uri = new Uri(wallpaperManager.GetNextRandomUrl());
        }

        /* Summary: 
         *   Set the user's wallpaper using the URI received from API call.
         * 
         * Parameters:
         *   N/A
         *   
         * Return:
         *   N/A
         */
        private void SetWallpaper()
        {
            while (setURIResult.IsCompleted == false)
            {
                Thread.Sleep(100);
            }
            DesktopWallpaper.Set(uri, DesktopWallpaper.Style.Fill);
            this.userWallpaperPictureBox.Image = wallpaperManager.GetUserWallpaper();
        }

        /* Summary: 
         *   Set registry key for running application on startup.
         * 
         * Parameters:
         *   runOnStart {bool}: whether application should run on startup
         *   
         * Return:
         *   N/A
         */
        private void SetRunOnStartup(bool runOnStart)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
            key.SetValue(StartupValue, runOnStart);
        }

        /* Summary: 
         *   Start polling for next wallpaper change.
         * 
         * Parameters:
         *   N/A
         *   
         * Return:
         *   N/A
         */
        private void SetTimer()
        { 
            if (timer != null)
                timer.Stop();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = PollingInterval; 
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        /* ------------------ Event Handlers ------------------ */

        /* Summary: 
         *   Handler for tab change.
         * 
         * Parameters:
         *   sender: The sender object
         *   e: Relevant event arguments
         *   
         * Return:
         *   N/A
         */
        private void materialTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            { 
                case 0:
                    this.saveFileIcon.Show();
                    break;
                default:
                    this.saveFileIcon.Hide();
                    break;
            }
        }

        /* Summary: 
         *   Handler for polling timer tick
         *   - Check if current DateTime is greater than next wallpaper change DateTime.
         *     - If so, change wallpaper and update the next DateTime.
         * 
         * Parameters:
         *   sender: The sender object
         *   e: Relevant event arguments
         *   
         * Return:
         *   N/A
         */
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= Properties.Settings.Default.nextWallpaperChangeDateTime)
            { 
                setWallpaperResult = delegateSetWallPaper.BeginInvoke(null, null);
                setURIResult = delegateSetURI.BeginInvoke(null, null);
                Properties.Settings.Default.nextWallpaperChangeDateTime = 
                    DateTime.Now.AddDays(Properties.Settings.Default.fetchIntervalDays);
            }
        }

        /* Summary: 
         *   Handler for window closure.
         *   - Minimize to system tray unless shutdown etc.
         * Parameters:
         *   sender: The sender object
         *   e: Relevant event arguments
         *   
         * Return:
         *   N/A
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

        /* Summary: 
         *   Handler for resizing of the form. Minize to system tray.
         * 
         * Parameters:
         *   sender: The sender object
         *   e: Relevant event arguments
         *   
         * Return:
         *   N/A
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

        /* Summary: 
         *   Handler for double clicking of notification icon
         * 
         * Parameters:
         *   sender: The sender object
         *   e: Relevant event arguments
         *   
         * Return:
         *   N/A
         */
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        /* Summary: 
         *   On click, show save file dialog and save current wallpaper.
         * 
         * Parameters:
         *   sender: The sender object
         *   e: Relevant event arguments
         *   
         * Return:
         *   N/A
         */
        private void saveFileIcon_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.Filter = "All Files (*.*)|*.*|Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            this.saveFileDialog.FilterIndex = 2;
            this.saveFileDialog.RestoreDirectory = true;
            
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                wallpaperManager.GetUserWallpaper().Save(this.saveFileDialog.FileName, ImageFormat.Bmp);
            }
        }

        /* Summary: 
         *   On click, invoke wallpaper change and API call for new wallpaper.
         * 
         * Parameters:
         *   sender: The sender object
         *   e: Relevant event arguments
         *   
         * Return:
         *   N/A
         */
        private void refreshWallpaperIcon_Click(object sender, EventArgs e)
        {
            setWallpaperResult = delegateSetWallPaper.BeginInvoke(null, null);
            setURIResult = delegateSetURI.BeginInvoke(null, null);
        }

        /* Summary: 
         *   On click, open page to the project github repo
         * 
         * Parameters:
         *   sender: The sender object
         *   e: Relevant event arguments
         *   
         * Return:
         *   N/A
         */
        private void repoLabelButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.github.com/SmallFundamentals/Deskt.op");
        }

        /* Summary: 
         *   On click, open page to my website.
         * 
         * Parameters:
         *   sender: The sender object
         *   e: Relevant event arguments
         *   
         * Return:
         *   N/A
         */
        private void myLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.blakeyu.me/");
        }

        /* Summary: 
         *   On keypress, allow input only if numerical or first decimal.
         * 
         * Parameters:
         *   sender: The sender object
         *   e: Relevant event arguments
         *   
         * Return:
         *   N/A
         */
        private void refreshIntervalTextField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        /* Summary: 
         *   Handles the saving of settings and invokes immediate actions.
         *   - Resets timer
         *   - Saves key to registry
         *   - Updates next date to update wallpaper
         * 
         * Parameters:
         *   sender: The sender object
         *   e: Relevant event arguments
         *   
         * Return:
         *   N/A
         */
        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            double intervalInDays = Convert.ToDouble(this.refreshIntervalTextField.Text);
            bool runOnStartup = this.materialCheckBox1.Checked;

            SetTimer();

            // Save startup settings to registry
            SetRunOnStartup(runOnStartup);

            Properties.Settings.Default.fetchIntervalDays = intervalInDays;
            Properties.Settings.Default.isRunOnStartup = runOnStartup;
            Properties.Settings.Default.nextWallpaperChangeDateTime = DateTime.Now.AddDays(intervalInDays);
            Properties.Settings.Default.Save();
        }
    }
}
