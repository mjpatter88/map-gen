using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace map_gen
{
    class MainWindowVM 
    {
        public ObservableCollection<Cell> Cells { get; set; }
        public MainWindowVM()
        {
            //Console.WriteLine("HERE");
            initializeData();
        }

        private void initializeData()
        {
            Cells = new ObservableCollection<Cell>();
            //Hard code some data to test
            Cells.Add(new HexCell(50, 50, 100));
            Cells.Add(new HexCell(100, 100, 100));
        }
    }
}
