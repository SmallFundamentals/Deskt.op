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
        private AsyncSetWallpaper delegateSetWallPaper;

        public MainForm()
        {
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

            delegateSetWallPaper = this.SetWallpaper;

            wallpaperManager = new SplashBaseWallpaperManager();
        }

        private void SetWallpaper()
        {
            var uri = new Uri(wallpaperManager.GetNextRandomUrl());
            DesktopWallpaper.Set(uri, DesktopWallpaper.Style.Fill);
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            delegateSetWallPaper.BeginInvoke(null, null);
        }
    }
}
