using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Point = System.Windows.Point;

namespace PerVisualForAllGraphics
{
    public class CustomCanvas : Canvas
    {
        private double _x = 10;
        private double _y = 10;

        public CustomCanvas()
        {
            MouseDown += OnMouseDown;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("OnMouseDown");
            _x += 10;
            _y += 10;
            this.RenderTransform = new TranslateTransform(_x, _y);
            this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Console.WriteLine("OnRender");
            this.Background = Brushes.Beige;
            // drawingContext.DrawEllipse(Brushes.Blue, new Pen(Brushes.Yellow, 2), new Point(100, 100), 50, 20);
            // base.OnRender(drawingContext);
            var group = DrawLines_10k();
            drawingContext.DrawDrawing(group);
        }

        private DrawingGroup DrawLines_10k()
        {
            // Todo: DrawDrawing 的进一步思考
            var pen = new Pen()
            {
                Thickness = 2,
                Brush = new SolidColorBrush(Colors.Red)
            };

            var group = new DrawingGroup();
            for (var i = 0; i < 100; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    var dv = new DrawingVisual();
                    using (var dc = dv.RenderOpen())
                    {
                        dc.DrawLine(pen, new Point(i * 5, j * 5), new Point((i + 1) * 5 - 1, j * 5));
                    }
                    group.Children.Add(dv.Drawing);
                }
            }

            return group;
        }
    }
}