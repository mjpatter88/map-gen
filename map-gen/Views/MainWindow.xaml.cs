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

namespace map_gen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = (MainWindowVM)FindResource("mainWindowViewModel");
        }

        private void ItemsControl_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Console.WriteLine(e.Delta);
            if (e.Delta > 0)
            {
                viewModel.ZoomLevel += 0.1;
            }
            else
            {
                viewModel.ZoomLevel -= 0.1;
            }
        }
    }
}
