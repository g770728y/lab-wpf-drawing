using System.Windows;
using System.Windows.Input;

namespace OneVisualForAllGraphics
{
    public partial class UseVisualCollection : Window
    {
        public double TranslateX { get; set; } = 100;
        public double TranslateY { get; set; } = 100;

        public UseVisualCollection()
        {
            this.DataContext = this;
            InitializeComponent();

            Loaded += OnLoad;
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            var host = new MyVisualHost();

            MyCanvas.Children.Add(host);
        }

        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summar>
        private void MyCanvas_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            TranslateX += 100;
            TranslateY += 100;
        }
    }
}