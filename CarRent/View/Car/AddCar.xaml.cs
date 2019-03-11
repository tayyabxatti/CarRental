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
using Xceed.Wpf.Toolkit;

namespace CarRent.View
{
    /// <summary>
    /// Interaction logic for AddCar.xaml
    /// </summary>
    public partial class AddCar : Window
    {
        carRentEntities _db = new carRentEntities();
        public AddCar()
        {
            InitializeComponent();
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            var responce = CarLogic.AddOrUpdate(new Common.ViewModel.CarVM
            {
                Make = tbCarMake.Text,
                Model = tbCompanyName.Text,
                RegistrationNo = tbCarRegistrationNo.Text,

            });
            if (responce.IsCompleted)
            {
                var listresponce = CarLogic.List();
                if (listresponce.IsCompleted) { 
                Vehicle.dataGrid.ItemsSource = listresponce.Object;
                this.Hide();
                }
            }

        }

        private void CbCarOwnerOwn_Checked(object sender, RoutedEventArgs e)
        {
            if (cbCarOwnerOwn.IsChecked == true)
            {
                cbCarOwnerNonPool.IsChecked = false;
                cbCarOwnerInvestor.IsChecked = false; 
            }
        }

        private void CbCarOwnerInvestor_Checked(object sender, RoutedEventArgs e)
        {
            if (cbCarOwnerInvestor.IsChecked == true)
            {
                cbCarOwnerOwn.IsChecked = false;
                cbCarOwnerNonPool.IsChecked = false;
            }
        }

        private void CbCarOwnerNonPool_Checked(object sender, RoutedEventArgs e)
        {
            if (cbCarOwnerNonPool.IsChecked == true)
            {
                cbCarOwnerOwn.IsChecked = false;
                cbCarOwnerInvestor.IsChecked = false;
            }
        }

        private void CbCarFuelStateFull_Checked(object sender, RoutedEventArgs e)
        {
            if (cbCarFuelStateFull.IsChecked == true)
            {
                cbCarFuelStateHalf.IsChecked = false;
                cbCarFuelStateQuarter.IsChecked = false;
                cbCarFuelStateEmpty.IsChecked = false;
            }
        }

        private void CbCarFuelStateQuarter_Checked(object sender, RoutedEventArgs e)
        {
            if(cbCarFuelStateQuarter.IsChecked == true)
            {
                cbCarFuelStateFull.IsChecked = false;
                cbCarFuelStateEmpty.IsChecked = false;
                cbCarFuelStateHalf.IsChecked = false;

            }

        }

        private void CbCarFuelStateHalf_Checked(object sender, RoutedEventArgs e)
        {
            if(cbCarFuelStateHalf.IsChecked == true)
            {
                cbCarFuelStateFull.IsChecked = false;
                cbCarFuelStateEmpty.IsChecked = false;
                cbCarFuelStateQuarter.IsChecked = false;
            }


        }

        private void CbCarFuelStateEmpty_Checked(object sender, RoutedEventArgs e)
        {
            if(cbCarFuelStateEmpty.IsChecked == true)
            {
                cbCarFuelStateFull.IsChecked = false;
                cbCarFuelStateQuarter.IsChecked = false;
                cbCarFuelStateHalf.IsChecked = false;
            }
        }
    }
}
