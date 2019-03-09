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
using System.Windows.Shapes;

namespace CarRent.View
{
    /// <summary>
    /// Interaction logic for AddDriver.xaml
    /// </summary>
    public partial class AddDriver : Window
    {

        public AddDriver()
        {
            InitializeComponent();
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            var response = DriverLogic.AddOrUpdate(new Common.ViewModel.DriverVM()
            {
                Name = tbDriverName.Text
            });
            if (response.IsCompleted)
            {
                var listResponse = DriverLogic.List();
                if (listResponse.IsCompleted)
                DriverMenu.dataGrid.ItemsSource = listResponse.Object;
                this.Hide();
            }
        }
    }
}
