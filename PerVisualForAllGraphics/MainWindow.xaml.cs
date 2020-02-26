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

namespace PerVisualForAllGraphics
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


        private void OpenInOneGroup(object sender, RoutedEventArgs e)
        {
            new InOneGroup().Show();
        }

        private void OpenIndividual(object sender, RoutedEventArgs e)
        {
            new Individual().Show();
        }

        private void OpenIndividual2(object sender, RoutedEventArgs e)
        {
            new Individual2().Show();
        }
    }
}