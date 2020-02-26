using System;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace DynamicAddOrRemoveGraphics
{
    public class TestControl: FrameworkElement
    {
        private readonly DrawingVisual _visual = new DrawingVisual();
        private bool _b;
        
        public TestControl()
        {
            Loaded += AddVisualToTree;
            Unloaded += RemoveVisualFromTree;

            Draw(_b);
            
            var timer = new DispatcherTimer(){Interval = new TimeSpan(0,0,2)};
            timer.Tick += (sender, args) =>
            {
                _b = !_b;
                Draw(_b );
                InvalidateVisual();
            };

            timer.Start();
        }

        private void Draw(bool b)
        {
            using var dc = _visual.RenderOpen();
            dc.DrawRectangle(Brushes.Aqua, new Pen(Brushes.Beige, 2),
                b ? new Rect(10, 10, 10, 10) : new Rect(100, 100, 100, 100));
        }

        private void RemoveVisualFromTree(object sender, RoutedEventArgs e)
        {
            RemoveVisualChild(_visual);
            RemoveLogicalChild(_visual);
        }

        private void AddVisualToTree(object sender, RoutedEventArgs e)
        {
            AddVisualChild(_visual);
            AddLogicalChild(_visual);
        }

        protected override Visual GetVisualChild(int index)
        {
            // Add时, 不管顺序, 只管向尾部Add
            // 在这里维护 visuals 的顺序
            return _visual;
        }

        protected override int VisualChildrenCount { get; } = 1;
    }
}