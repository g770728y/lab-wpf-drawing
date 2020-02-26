using System;
using System.Windows;
using System.Windows.Media;

namespace PerVisualForAllGraphics
{
    public partial class Individual : Window
    {
        private VisualCollection _children;

        public Individual()
        {
            InitializeComponent();

            this.Loaded += OnLoad;
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            _children = new VisualCollection(this.MyCanvas);
            DrawLines_10k();
        }

        private void DrawLines_10k()
        {
            var pen = new Pen()
            {
                Thickness = 2,
                Brush = new SolidColorBrush(Colors.Red)
            };
            
            for (var i = 0; i < 100; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    var dv = new DrawingVisual();
                    using var dc = dv.RenderOpen();

                    dc.DrawLine(pen, new Point(i * 5, j * 5), new Point((i + 1) * 5 - 1, j * 5));
                    _children.Add(dv);
                }
            }
        }

        protected override int VisualChildrenCount { get => _children == null ? 0 : _children.Count; }

        protected override Visual GetVisualChild(int index)
        {
            if (index < _children.Count || _children == null)
            {
                return _children[index];
            } 
            throw new IndexOutOfRangeException();
        }
    }
}