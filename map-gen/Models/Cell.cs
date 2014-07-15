using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace map_gen
{
    abstract class Cell : INotifyPropertyChanged     //We need to implement this interface so we can bind to the properties.
    {
        private int _x;
        private int _y;
        private int _size;

        public int X 
        {
            get
            {
                return _x;
            }
            set
            {
                if (_x != value)
                {
                    OnPropertyChanged("X");
                    OnPropertyChanged("negX");
                    _x = value;
                }
            }
        }
        public int negX 
        {
            get
            {
                return -_x;
            }
        }
        public int Y 
        {
            get
            {
                return _y;
            }
            set
            {
                if (_y != value)
                {
                    OnPropertyChanged("Y");
                    OnPropertyChanged("negY");
                    _y = value;
                }
            }
        }
        public int negY 
        {
            get
            {
                return -_y;
            }
        }
        public int Size 
        {
            get
            {
                return _size;
            }
            set
            {
                if (_size != value)
                {
                    OnPropertyChanged("Size");
                    _size = value;
                }
            }
        }
        abstract public PointCollection Points { get; }

        public Cell()
        {

        }

        public Cell(int x, int y, int size)
        {
            _x = x;
            _y = y;
            _size = size;
        }

        // Implementing the INotifyPropertyChanged interface.
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
