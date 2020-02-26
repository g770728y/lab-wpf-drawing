using System.Windows;
using System.Windows.Input;

namespace OneVisualForAllGraphics_WithRedraw
{
    public partial class ManualWindow : Window
    {

        public double TranslateX { get; set; } = 100;
        public double TranslateY { get; set; } = 100;
        
        public ManualWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            Loaded += OnLoad;
        }

        private MyVisualHost host;
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            host = new MyVisualHost();
            
            MyCanvas.Children.Add(host);
        }

        private void MyCanvas_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            TranslateX += 50;
            TranslateY += 50;
            
            MyCanvas.Children.Remove(host);
            MyCanvas.Children.Add(host);
        }
    }
}