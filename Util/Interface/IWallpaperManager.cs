using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskt.op.Util.Interface
{
    interface IWallpaperManager
    {
        Image GetUserWallpaper();
        string GetNextRandomUrl();
        string getUrl();
        Uri getUri();
    }
}
