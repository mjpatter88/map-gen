using System;
using System.Collections.Generic;
using System.IO;
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

        //At this point the image has the same dimensions and view as the canvas
        private void butExport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.AddExtension = true;
            dlg.OverwritePrompt = true;
            dlg.DefaultExt = ".png";
            dlg.Filter = "PNG Files (*.png)|*.png";

            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                Console.WriteLine(filename);

                // Create the image and write it to the file
                Uri path = new Uri(filename);
                Size size = new Size(MainCanvas.ActualWidth, MainCanvas.ActualHeight);

                RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96d, 96d, PixelFormats.Pbgra32);
                renderBitmap.Render(MainCanvas);

                using (FileStream outStream = new FileStream(path.LocalPath, FileMode.Create))
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                    encoder.Save(outStream);
                }
            }
        }
    }
}
