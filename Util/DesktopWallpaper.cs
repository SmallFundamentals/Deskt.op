using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Deskt.op.Util
{
    // Modified from http://stackoverflow.com/questions/1061678/change-desktop-wallpaper-using-code-in-net/1061682#1061682

    public sealed class DesktopWallpaper
    {
        DesktopWallpaper() { }   

        public enum Style : int
        {
            Centered,
            Fill,
            Stretched,
            Tiled
        }

        public static Tuple<int, int> GetPrimaryScreenResolution()
        {
            System.Drawing.Rectangle resolution = Screen.PrimaryScreen.Bounds;
            return new Tuple<int, int>(resolution.Width, resolution.Height);
        }

        public static Boolean Set(Uri uri, Style style)
        {
            Stream stream = new System.Net.WebClient().OpenRead(uri.ToString());
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

            // Random wallpaper name to prevent override problem.
            string tempPath = Path.Combine(Path.GetTempPath(), GenerateRandomFilename());
            img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            switch (style)
            {
                case Style.Centered:
                {
                    key.SetValue(@"WallpaperStyle", 1.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                }
                case Style.Stretched:
                {
                    key.SetValue(@"WallpaperStyle", 2.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                }
                case Style.Tiled:
                {
                    key.SetValue(@"WallpaperStyle", 1.ToString());
                    key.SetValue(@"TileWallpaper", 1.ToString());
                    break;
                }
                case Style.Fill:
                {
                    key.SetValue(@"WallpaperStyle", 10.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                }
            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                tempPath,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);

            return true;
        }

        private static string GenerateRandomFilename()
        {
            byte[] randomNumber = new byte[1];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomNumber);
            
            return string.Format("Deskt.op_{0}.bmp", randomNumber[0]);;
        }

        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
    }
}
