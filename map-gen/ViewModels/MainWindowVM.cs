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
        private double _translateX;
        private double _translateY;

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
        public double TranslateX
        {
            get
            {
                return _translateX;
            }
            set
            {
                // Only allow zooming out to 10% for now.
                if (_translateX != value)
                {
                    _translateX = value;
                    OnPropertyChanged("TranslateX");
                }
            }
        }
        public double TranslateY
        {
            get
            {
                return _translateY;
            }
            set
            {
                // Only allow zooming out to 10% for now.
                if (_translateY != value)
                {
                    _translateY = value;
                    OnPropertyChanged("TranslateY");
                }
            }
        }

        public ObservableCollection<Cell> Cells { get; set; }

        public MainWindowVM()
        {
            //Console.WriteLine("HERE");
            initializeData();
            _zoomLevel = 1.0;
            _translateX = 0.0;
            _translateY = 0.0;
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
