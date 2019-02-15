using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Topology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinSpatialControl.Common
{
    #region  界面绘制
    class MapCreateFeatureLayer
    {
        private Map m_Map;
        public MapCreateFeatureLayer(Map _map)
        {
            m_Map = _map;
        }
        /// <summary>
        /// 创建点
        /// </summary>
        private void CreateNewPointLayer()
        {
            FeatureSet fs = new FeatureSet(FeatureType.Point);
            DotSpatial.Topology.Point point0 = new DotSpatial.Topology.Point(0, 0);
            fs.AddFeature(point0);
            MapPointLayer layer = new MapPointLayer(fs)
            {
                LegendText = "点"
            };
            m_Map.Layers.Add(layer);
        }
        /// <summary>
        /// 创建线
        /// </summary>
        private void CreateNewLineLayer()
        {
            FeatureSet fs = new FeatureSet(FeatureType.Line);
            List<Coordinate> coords = new List<Coordinate>()
            {
                new Coordinate(0,0),
                new Coordinate(10,10),
                new Coordinate(20,15)
            };
            LineString line = new LineString(coords);
            fs.AddFeature(line);
            MapLineLayer layer = new MapLineLayer(fs)
            {
                LegendText = "线"
            };
            m_Map.Layers.Add(layer);
        }

        /// <summary>
        /// 创建面
        /// </summary>
        private void CreateNewPolygonLayer()
        {
            FeatureSet fs = new FeatureSet(FeatureType.Polygon);
            List<Coordinate> coords = new List<Coordinate>()
            {
                new Coordinate(25,25),
                new Coordinate(35,25),
                new Coordinate(35,35),
                new Coordinate(25,35)
            };
            Polygon polygon = new Polygon(coords);
            fs.AddFeature(polygon);
            MapPolygonLayer layer = new MapPolygonLayer(fs)
            {
                LegendText = "面"
            };
            m_Map.Layers.Add(layer);
        }
        /// <summary>
        /// 创建矩形
        /// </summary>
        public void CreateRectangleLayer(double xmin, double ymin, double xmax, double ymax)
        {
            FeatureSet fs = new FeatureSet(FeatureType.Polygon);
            for (int i = 0; i < 50; i++)
            {
                List<Coordinate> coords = new List<Coordinate>()
                {
                    new Coordinate(xmin+5000*i,ymin+5000*i),
                    new Coordinate(xmin+5000*i,ymax-5000*i),
                    new Coordinate(xmax-5000*i,ymax-5000*i),
                    new Coordinate(xmax-5000*i,ymin+5000*i),
                    new Coordinate(xmin+5000*i,ymin+5000*i)
                };
                Polygon polygon = new Polygon(coords);
                fs.AddFeature(polygon);
            }
           
            MapPolygonLayer layer = new MapPolygonLayer(fs)
            {
                LegendText = "面"
            };
            layer.Projection = m_Map.Projection;
            layer.Symbolizer = new DotSpatial.Symbology.PolygonSymbolizer(System.Drawing.Color.FromArgb(255, 0, 0), System.Drawing.Color.FromArgb(0, 0, 255));
            m_Map.Layers.Add(layer);
           
        }
        /// <summary>
        /// 传入多个矩形并在图层上面绘制矩形
        /// </summary>
        /// <param name="_rectangle"></param>
        public void CreateRecangleLayer(List<System.Drawing.Rectangle> _rectangle)
        {

        }
        public void ClearAllLayer()
        {
            if(m_Map.Layers.Any(v=>v.LegendText=="BaseMap"))
            foreach (IMapLayer _mapLayer in m_Map.Layers)
            {
                if (_mapLayer.LegendText.Equals("BaseMap"))
                    continue;
                    m_Map.Layers.Remove(_mapLayer);
            }
        }
    }
    #endregion

}
