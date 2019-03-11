using ApplicationDb.DbLogic;
using Common.ViewModel;
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
            VehicleGrid.ItemsSource = CarLogic.List().Object;
            dataGrid = VehicleGrid;
        }
        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            AddCar addCar = new AddCar();
            addCar.ShowDialog();
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int Id = (VehicleGrid.SelectedItem as CarVM).Id;
            UpdateCar updateCar = new UpdateCar(Id);
            updateCar.ShowDialog();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int selectedId = (VehicleGrid.SelectedItem as CarVM).Id;
            var responce = CarLogic.Delete(new CarVM
            { Id = selectedId,
            });
            if (responce.IsCompleted)
            {
                VehicleGrid.ItemsSource = CarLogic.List().Object;
            }
        }
    }
}
