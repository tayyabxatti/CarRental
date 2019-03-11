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
    /// <summary>
    /// Interaction logic for DriverMenu.xaml
    /// </summary>
    public partial class DriverMenu : UserControl
    {
        carRentEntities _db = new carRentEntities();
        public static DataGrid dataGrid;

        public DriverMenu()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            DriverGrid.ItemsSource = DriverLogic.List().Object;
            dataGrid = DriverGrid;
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int Id = (DriverGrid.SelectedItem as DriverVM).Id;
            UpdateDriver updateDriver = new UpdateDriver(Id);
            updateDriver.ShowDialog();

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int selectedId = (DriverGrid.SelectedItem as DriverVM).Id;
            var responce = DriverLogic.Delete(new Common.ViewModel.DriverVM
            {
                Id = selectedId,

            });
            if (responce.IsCompleted == true)
            {
                DriverGrid.ItemsSource = DriverLogic.List().Object;
            }
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            AddDriver driver = new AddDriver();
            driver.ShowDialog();
        }
    }
}
