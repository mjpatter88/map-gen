using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace map_gen
{
    class MainWindowVM : INotifyPropertyChanged
    {
        private double _zoomLevel;
        public double ZoomLevel
        {
            get
            {
                return _zoomLevel;
            }
            set
            {
                // Only allow zooming out to 10% for now.
                if (_zoomLevel != value && value > 0.1)
                {
                    _zoomLevel = value;
                    OnPropertyChanged("ZoomLevel");
                }
            }
        }

        public ObservableCollection<Cell> Cells { get; set; }

        public MainWindowVM()
        {
            //Console.WriteLine("HERE");
            initializeData();
            _zoomLevel = 1.0;
        }

        private void initializeData()
        {
            Cells = new ObservableCollection<Cell>();
            //Hard code some data to test
            Cells.Add(new HexCell(50, 50, 100));
            Cells.Add(new HexCell(100, 100, 100));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
