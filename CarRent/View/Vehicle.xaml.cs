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

namespace CarRent.View
{

   
    public partial class Vehicle : UserControl
    {
        carRentEntities _db = new carRentEntities();
        public static DataGrid dataGrid;
        public Vehicle()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            VehicleGrid.ItemsSource = _db.Cars.ToList();
            dataGrid = VehicleGrid;
        }
    }
}
