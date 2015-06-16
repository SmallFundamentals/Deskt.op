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

            InitializeComponent();

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
    }
}
