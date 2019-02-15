using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WinSpatialControl.Common;
using DotSpatial.Controls;
using DotSpatial.Plugins.Measure;

namespace WinSpatialControl.UI
{
    public partial class Ctr3DToolBar : UserControl
    {
        public Ctr3DToolBar( )
        {
            InitializeComponent();  
            SetWindowRegion();
        }
        private Map m_BuddyMap;
        public void SetBuddyMap(Map _BuddyMap)
        {
            this.m_BuddyMap = _BuddyMap;
        }
        private void ToolPanel_MouseDown(object sender, MouseEventArgs e)
        {
            DragForm.moveForm(this);
        }

        private void zoomIn_Click(object sender, EventArgs e)
        {
            m_BuddyMap.FunctionMode = FunctionMode.ZoomIn;
        }

        private void zoomOut_Click(object sender, EventArgs e)
        {
            m_BuddyMap.FunctionMode = FunctionMode.ZoomOut;
        }

        private void rotatePic_Click(object sender, EventArgs e)
        {
            m_BuddyMap.FunctionMode = FunctionMode.Pan;
        }

        private void clearPic_Click(object sender, EventArgs e)
        {
            
        }

        private void czmeasure_Click(object sender, EventArgs e)
        {
            

        }

        private void spmeasure_Click(object sender, EventArgs e)
        {
            MapFunctionMeasure _measure=default(MapFunctionMeasure) ;

            if (_measure == null)
                _measure = new MapFunctionMeasure(m_BuddyMap);

            if (!m_BuddyMap.MapFunctions.Contains(_measure))
                m_BuddyMap.MapFunctions.Add(_measure);

            m_BuddyMap.FunctionMode = FunctionMode.None;
            m_BuddyMap.Cursor = Cursors.Cross;
            _measure.Activate();
        }

        private void threeAreaMeasure_Click(object sender, EventArgs e)
        {
            
        }

        private void dAreaMeasure_Click(object sender, EventArgs e)
        {
            
        }

        private void kjMeasure_Click(object sender, EventArgs e)
        {
           
        }

        private void Ctr3DToolBar_MouseDown(object sender, MouseEventArgs e)
        {
            DragForm.moveForm(this);
        }

        public void SetWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 6);
            this.Region = new Region(FormPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect">窗体大小</param>
        /// <param name="radius">圆角大小</param>
        /// <returns></returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            path.AddArc(arcRect, 180, 90);//左上角

            arcRect.X = rect.Right - diameter;//右上角
            path.AddArc(arcRect, 270, 90);

            arcRect.Y = rect.Bottom - diameter;// 右下角
            path.AddArc(arcRect, 0, 90);

            arcRect.X = rect.Left;// 左下角
            path.AddArc(arcRect, 90, 90);
            path.CloseAllFigures();
            return path;

        }

        private void northPic_Click(object sender, EventArgs e)
        {
            
        }
    }
}
