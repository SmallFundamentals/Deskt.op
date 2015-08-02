using System;
using System.Drawing;

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
