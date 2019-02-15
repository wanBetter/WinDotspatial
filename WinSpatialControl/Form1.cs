using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotSpatial.Controls;

namespace WinSpatialControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UCMapControl mapControl = new UCMapControl() { Dock = DockStyle.Fill };
            this.Controls.Add(mapControl);
            
        }
    }
}
