﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;

using Deskt.op.Util.Interface;

namespace Deskt.op.Util
{
    public abstract class BaseWallpaperManager : IWallpaperManager
    {
        private const int SPI_GETDESKWALLPAPER = 0x73;
        private const int MAX_LENGTH = 255;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public Image GetUserWallpaper()
        {
            string wallpaperPath = new string('\0', MAX_LENGTH);
            SystemParametersInfo(SPI_GETDESKWALLPAPER, wallpaperPath.Length, wallpaperPath, 0);
            wallpaperPath = wallpaperPath.Substring(0, wallpaperPath.IndexOf('\0'));

            Console.WriteLine("User wallpaper path: " + wallpaperPath);

            // TODO: Possible exception here if previous wallpaper gets moved
            return Image.FromFile(wallpaperPath);
        }
        public abstract string GetNextRandomUrl();
        public abstract string getUrl();
        public abstract Uri getUri();
    }
}
