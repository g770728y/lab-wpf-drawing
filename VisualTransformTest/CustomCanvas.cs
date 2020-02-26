using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VisualTransformTest
{
    public class CustomCanvas : Canvas
    {
        private DrawingVisual _drawingVisual;
        public CustomCanvas()
        {
            RenderTransformOrigin = new Point(0, 0.5);
            var transformGroup = new TransformGroup();
            transformGroup.Children.Add(new TranslateTransform(100, 100));
            transformGroup.Children.Add(new ScaleTransform(1, -1));
            RenderTransform = transformGroup; 

            Loaded += OnLoad;
            Unloaded += OnUnload;
        }

        private void OnUnload(object sender, RoutedEventArgs e)
        {
            RemoveLogicalChild(_drawingVisual);
            RemoveVisualChild(_drawingVisual);
        }

        private void OnLoad(object sender, RoutedEventArgs routedEventArgs)
        {
            AddVisualChild(_drawingVisual);
            AddLogicalChild(_drawingVisual);
            Redraw();
        }

        public void Redraw()
        {
            _drawingVisual = GetDrawingVisual();
        }
        
        private DrawingVisual GetDrawingVisual()
        {
            var drawingVisual = new DrawingVisual();
            using (var dc = drawingVisual.RenderOpen())
            {
                dc.DrawRectangle(Brushes.Aqua, null, new Rect(0,0,100, 100));
            }

            return drawingVisual;
        }

        protected override int VisualChildrenCount { get; } = 1;
        protected override Visual GetVisualChild(int index)
        {
            return _drawingVisual;
        }
    }
}