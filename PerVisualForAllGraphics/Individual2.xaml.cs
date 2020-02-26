using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace PerVisualForAllGraphics
{
    public partial class Individual2 : Window
    {
        private List<Visual> _children;

        public Individual2()
        {
            InitializeComponent();
            Console.WriteLine("使用AddVisualChild, 而非Collection, 以便进行下一步修改");

            Loaded += OnLoad;
            Unloaded += OnUnload;
        }

        private void OnUnload(object sender, RoutedEventArgs e)
        {
            _children.ForEach(child =>
            {
                RemoveLogicalChild(child);
                RemoveVisualChild(child);
            });
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            _children = new List<Visual>();
            DrawLines_10k();
            
            _children.ForEach(child =>
            {
                AddLogicalChild(child);
                AddVisualChild(child);
            });
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

        protected override int VisualChildrenCount { get => _children?.Count ?? 0; }

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