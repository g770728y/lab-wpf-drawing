using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OneVisualForAllGraphics
{
    public class MyVisualHost : FrameworkElement
    {
        private readonly VisualCollection _canvasChildren;

        public MyVisualHost()
        {
            _canvasChildren = new VisualCollection(this);
            DrawLines_10k();
        }

        /// <summary>
        /// 画10000条线, 非常慢
        /// </summary>
        private void DrawLines_10k()
        {
            var dv = new DrawingVisual();
            using (var dc = dv.RenderOpen())
            {
                // Todo: DrawDrawing 的进一步思考
                var pen = new Pen()
                {
                    Thickness = 2,
                    Brush = new SolidColorBrush(Colors.Red)
                };
                Console.WriteLine(1);
                for (var i = 0; i < 100; i++)
                {
                    for (var j = 0; j < 100; j++)
                    {
                        dc.DrawLine(pen, new Point(i * 5, j * 5), new Point((i + 1) * 5 - 1, j * 5));
                    }
                }

                Console.WriteLine(2);
            }

            _canvasChildren.Add(dv);
        }

        protected override int VisualChildrenCount { get; } = 1;

        protected override Visual GetVisualChild(int index)
        {
            if (index < 1)
            {
                return _canvasChildren[index];
            }

            throw new IndexOutOfRangeException();
        }
    }
}