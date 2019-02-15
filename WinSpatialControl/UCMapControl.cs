using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotSpatial.Controls;
using WinSpatialControl.Common;

namespace WinSpatialControl
{
    public partial class UCMapControl : UserControl
    {
        private string m_BaseMap = @"E:\shp\test.shp";
        private static Map m_MapControl=new Map() { Dock=DockStyle.Fill};
        IMapLayer pMapLayer = default(IMapLayer);
        public Map MapControl { get; } = m_MapControl;
        public UCMapControl()
        {
            InitializeComponent();
            InitMap();

            AddSecretLayer(pMapLayer.Extent.MinX , pMapLayer.Extent.MinY , pMapLayer.Extent.MaxX , pMapLayer.Extent.MaxY , string.Empty); 
        }
        private void InitMap(double xmin, double ymin, double xmax, double ymax, string msg,string baseMap)
        {

        }
        private void AddSecretLayer(double xmin, double ymin, double xmax, double ymax, string msgLabel)
        {
            MapCreateFeatureLayer _mapCreateFeatureLayer = new MapCreateFeatureLayer(m_MapControl);
            _mapCreateFeatureLayer.CreateRectangleLayer(xmin, ymin, xmax,ymax);
        }
        private void InitMap()
        {
            this.ctr3DToolBar1.SetBuddyMap(m_MapControl);
            m_MapControl.GeoMouseMove += MapControl_GeoMouseMove;
            m_MapControl.MouseClick += MapControl_GeoMouseClick;
            pMapLayer= m_MapControl.AddLayer(m_BaseMap);
            this.Controls.Add(m_MapControl);
        }
        void MapControl_GeoMouseMove(object sender, GeoMouseArgs e)
        {
            string locStr = "X:" + e.GeographicLocation.X.ToString("F6");
            locStr += "Y:" + e.GeographicLocation.Y.ToString("F6");
            this.label1.Text = locStr;
        }

        void MapControl_GeoMouseClick(object sender, MouseEventArgs e)
        {
            if (m_MapControl.FunctionMode == FunctionMode.None)
            {
                GeoMouseArgs args = new GeoMouseArgs(e, m_MapControl); //屏幕坐标到地图坐标转换
                var _startPoint = e.Location;//屏幕起始点坐标
                var _geoStartPoint = args.GeographicLocation;//地图起始点坐标

                var curViewExtent = m_MapControl.ViewExtents;
                var curCenter = curViewExtent.Center;

                //m_MapControl.ViewExtents.SetCenter(_geoStartPoint);
                m_MapControl.Refresh();
            }
        }
    }
}
