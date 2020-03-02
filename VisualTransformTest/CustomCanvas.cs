using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Collections.Generic;

namespace VisualTransformTest
{
    public class CustomCanvas : Canvas
    {
        private DrawingVisual _drawingVisual;

        public CustomCanvas()
        {
            _drawingVisual = new DrawingVisual();
            Loaded += OnLoad;
            Unloaded += OnUnload;
        }

        private void OnUnload(object sender, RoutedEventArgs e)
        {
            // RemoveLogicalChild(_drawingVisual);
            RemoveVisualChild(_drawingVisual);
        }

        private void OnLoad(object sender, RoutedEventArgs routedEventArgs)
        {
            // AddLogicalChild(_drawingVisual);
            AddVisualChild(_drawingVisual);
            // Redraw();
        }

        private double _x = 0;
        private double _y = 0;

        public void Redraw()
        {
            Console.WriteLine(_x);
            GetDrawingVisual();
            _x += 100;
            _y += 100;
        }

        private void GetDrawingVisual()
        {
                // var drawingVisualChild = new DrawingVisual();
                // _drawingVisual.Children.Add(drawingVisualChild);
                // using (var dcChild = drawingVisualChild.RenderOpen())
                // {
                //     dcChild.DrawRectangle(Brushes.Aqua, null, new Rect(_x - 20, _y - 20, 10, 10));
                // }
            using (var dc = _drawingVisual.RenderOpen())
            {
                dc.DrawRectangle(Brushes.Aqua, null, new Rect(_x, _y, 100, 100));
                var drawingVisualChild = new DrawingVisual();
                _drawingVisual.Children.Add(drawingVisualChild);
                using (var dcChild = drawingVisualChild.RenderOpen())
                {
                    dcChild.DrawRectangle(Brushes.Aqua, null, new Rect(_x - 20, _y - 20, 10, 10));
                }
            }
        }

        protected override int VisualChildrenCount { get; } = 1;

        protected override Visual GetVisualChild(int index)
        {
            var a = (a1:1, a2:new Point(3, 3));
            var b = ((1, 2, 3), (4, 5, 6));
            var (b1, b2) = b;
            
            return _drawingVisual;
        }
    }
}