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
        private Point oldPosition;
        private bool isDragging = false;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = (MainWindowVM)FindResource("mainWindowViewModel");
        }

        private void ItemsControl_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                viewModel.ZoomLevel += 0.1;
            }
            else
            {
                viewModel.ZoomLevel -= 0.1;
            }
        }

        // The following three methods implement the drag to pan functionality of the main map
        // This method doesn't seem very MVVM, but I'm not sure of another way to do it right now.
        private void ItemsControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            oldPosition = e.GetPosition(this);
            ((ItemsControl)sender).CaptureMouse();
        }

        private void ItemsControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            ((ItemsControl)sender).ReleaseMouseCapture();
        }

        private void ItemsControl_MouseMove(object sender, MouseEventArgs e)
        {
            //We only care about this if we are dragging
            if (isDragging)
            {
                Point curPos = e.GetPosition(this);
                viewModel.TranslateX += curPos.X - oldPosition.X;
                viewModel.TranslateY += curPos.Y - oldPosition.Y;
                oldPosition = curPos;
            }
        }
    }
}
