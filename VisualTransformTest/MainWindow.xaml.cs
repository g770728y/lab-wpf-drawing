using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisualTransformTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnPanLeft(object sender, RoutedEventArgs e)
        {
            // var transformGroup = new TransformGroup();
            // transformGroup.Children.Add(new TranslateTransform(200, 100));
            // transformGroup.Children.Add(new ScaleTransform(1, -1));
            // MyCanvas.RenderTransform = transformGroup; 
        }

        private void AddRectButton_Click(object sender, RoutedEventArgs e)
        {
            MyCanvas.Redraw();
        }
    }
}