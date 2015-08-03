using System;

namespace Deskt.op.Util
{
    public class UnsplashItWallpaperManager : BaseWallpaperManager
    {
        private Tuple<int, int> Resolution { get; set; }
        private string Url;
        public bool isRandom { get; set; }
        public bool isBlur { get; set; }
        public bool isGrayscale { get; set; }
        public bool isMyPicks { get; set; }

        public UnsplashItWallpaperManager(bool isRandom = true, bool isBlur = false, bool isGrayscale = false,
                bool isMyPicks = false) {
            this.isRandom = isRandom;
            this.isBlur = isBlur;
            this.isGrayscale = isGrayscale;
            this.isMyPicks = isMyPicks;
        }

        public UnsplashItWallpaperManager(Tuple<int, int> resolution, bool isRandom = true, bool isBlur = false, 
                bool isGrayscale = false, bool isMyPicks = false) {
            this.Resolution = resolution;
            this.isRandom = isRandom;
            this.isBlur = isBlur;
            this.isGrayscale = isGrayscale;
        }

        public override string GetNextRandomUrl()
        {
            if (Resolution == null)
            {
                throw new NullReferenceException();
            }

            string urlComponentGrayscale = "";
            if (isGrayscale)
            {
                urlComponentGrayscale = GRAYSCALE;
            }

            Url = String.Format(BASE_ROUTE, urlComponentGrayscale, Resolution.Item1, Resolution.Item2,
                ConstructQueryParam());

            return Url;
        }

        public override string getUrl()
        {
            return this.Url;
        }

        public override Uri getUri()
        { 
            return new Uri(getUrl());
        }

        private string ConstructQueryParam()
        {
            string urlComponentRandom = "";
            string urlComponentBlur = "";


            if (isRandom)
            {
                urlComponentRandom = QUERY_PARAM.RANDOM;
            }
            if (isBlur)
            {
                urlComponentBlur = QUERY_PARAM.BLUR;
            }
            if (isMyPicks)
            {
                // TODO 
            }

            return String.Format("?{0}{1}", urlComponentRandom, urlComponentBlur);
        }

        private const string BASE_ROUTE = "https://unsplash.it/{0}{1}/{2}?{3}";
        private const string GRAYSCALE = "g/";
        private struct QUERY_PARAM
        {
            public const string RANDOM = "&random";
            public const string BLUR = "&blur";
            public const string QUERY_IMAGE_BY_ID = "&image={0}";
        }
    }
}
