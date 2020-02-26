using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace OneVisualForAllGraphics_WithRedraw
{
    public partial class AutoWindow : Window
    {
        public double TranslateX { get; set; } = 100;
        public double TranslateY { get; set; } = 100;

        public AutoWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }


        private void MyCanvas_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            // TranslateX += 50;
            // TranslateY += 50;
            //
            // this.MyCanvas.InvalidateVisual();
        }

    }
}