using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;
using System.Drawing;
using System.Net;
using System.IO;

namespace WinSpatialControl.Common
{
    class WMSLayer
    {
    }
    abstract class StaticImageLayer : Layer, IMapLayer
    {
        public abstract string UrlFormat { get; }

        private Bitmap syncBuffer;
        public int ZoomLevel { get; set; }
        public Size WindowSize { get; set; }

        public StaticImageLayer()
        {
            WindowSize = new Size();
            ZoomLevel = 0;
        }

        public void DrawRegions(MapArgs args, List<Extent> regions)
        {
            foreach (var region in regions)
            {
                if (region.Width <= 0 || region.Height <= 0)
                    continue;
                if (WindowSize.Width <= 0 || WindowSize.Height <= 0 || ZoomLevel <= 0)
                    continue;
                var bmp = GetBitmap(region);
                if (bmp == null)
                    continue;
                args.Device.DrawImage(bmp, 0, 0);
            }
        }

        protected virtual Image GetBitmap(Extent e)
        {
            string geoserverUrl = GetURL(e);
            Console.WriteLine(geoserverUrl);
            var wc = new WebClient();
            var bytes = wc.DownloadData(geoserverUrl);
            if (bytes.Length < 400)
            {
                var text = Encoding.GetEncoding("UTF-8").GetString(bytes);
                Console.WriteLine(text);
                return null;
            }
            var str = new MemoryStream(bytes);
            syncBuffer = new Bitmap(str);
            str.Close();
            str.Dispose();
            return syncBuffer;
        }

        protected virtual string GetURL(Extent e)
        {
            return string.Format(UrlFormat, e.Center.X, e.Center.Y, WindowSize.Width, WindowSize.Height, ZoomLevel);
        }
    }
}
