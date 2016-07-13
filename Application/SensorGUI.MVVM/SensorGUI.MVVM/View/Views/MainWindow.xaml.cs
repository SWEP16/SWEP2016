using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SensorGUI.MVVM
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ribbon_Loaded(object sender, RoutedEventArgs e) {
            var ribbon = sender as Ribbon;
            var tabGrid = ribbon.GetDescendants<Grid>().FirstOrDefault();
            tabGrid.RowDefinitions[0].Height = new GridLength(0, System.Windows.GridUnitType.Pixel);
            tabGrid.RowDefinitions[1].Height = new GridLength(0, System.Windows.GridUnitType.Pixel);

            foreach (Line line in ribbon.GetDescendants<Line>())
                line.Visibility = Visibility.Collapsed;
        }
    }
}
