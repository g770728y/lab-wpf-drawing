using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrawingTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DrawingEllipse();
        }

        // 用 一个ellipse+rect的混合体, 填充为background
        private void DrawingEllipse()
        {
            EllipseGeometry ellipse = new EllipseGeometry(new Point(50,50), 50, 20);
            var rect = new RectangleGeometry(new Rect(50,50,50,20),5,5);
            PathGeometry path = Geometry.Combine(ellipse, rect, GeometryCombineMode.Xor, null);
            var drawing = new GeometryDrawing(Brushes.LightBlue, new Pen(Brushes.Green, 2), path);
            
            var background = new DrawingBrush(drawing);
            background.Viewport = new Rect(0,0,0.5,0.5);
            background.TileMode = TileMode.Tile;
            Background = background;
        }
    }
}