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
using MaterialSkin.Animations;
using MaterialSkin.Controls;

using Deskt.op;
using Deskt.op.Wallpaper;


namespace Deskt.op.View
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private delegate void AsyncSetWallpaper();
        private AsyncSetWallpaper delly;

        public MainForm()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            delly = new AsyncSetWallpaper(this.SetWallpaper);
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            delly.BeginInvoke(null, null);
        }

        private void SetWallpaper()
        {
            var uri = new Uri("https://download.unsplash.com/photo-1431184052543-809fa8cc9bd6");
            Wallpaper.DesktopWallpaper.Set(uri, Wallpaper.DesktopWallpaper.Style.Fill);
        }
    }
}
