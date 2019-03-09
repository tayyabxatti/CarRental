using ApplicationDb.DbLogic;
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
    /// Interaction logic for UpdateDriver.xaml
    /// </summary>
    public partial class UpdateDriver : Window
    {
        private int _id;
        public UpdateDriver(int DriverId)
        {
            InitializeComponent();
            _id = DriverId;
            Load();

        }
        public void Load()
        {

            var response = DriverLogic.Get(_id);
            if (response.IsCompleted && response.Object != null)
                tbDriverName.Text = response.Object.Name;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var response = DriverLogic.AddOrUpdate(new Common.ViewModel.DriverVM()
            {
                Id = _id,
                Name = tbDriverName.Text
            }, true);
            if (response.IsCompleted)
            {
                var listResponse = DriverLogic.List();
                if(listResponse.IsCompleted)
                DriverMenu.dataGrid.ItemsSource = listResponse.Object;
                this.Hide();
            }
        }
    }
}
