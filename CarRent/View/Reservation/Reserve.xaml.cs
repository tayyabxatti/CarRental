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
    /// Interaction logic for Reserve.xaml
    /// </summary>
    public partial class Reserve : Window
    {
        carRentEntities _db = new carRentEntities();
        public Reserve()
        {
            InitializeComponent();
            fillCombo();
        }
        public void fillCombo()
        {

            var carnames = _db.Cars.ToList();
            foreach (var item in carnames)
            {
                cbCarMake.Items.Add($"{item.CarMake} : {item.CarRegistrationNo}");
            }
            var clientnames = _db.Clients.ToList();
            foreach (var client in clientnames)
            {
                cbRentersName.Items.Add($"{client.ClientName}");
            }
            var drivernames = _db.Drivers.ToList();
            foreach (var item in drivernames)
            {
                cbDriverName.Items.Add($"{item.DriverName}");
            }
        }
        private void CbDriverName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void CbCarMake_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbCarRegistrationNo.Text = cbCarMake.SelectedValue.ToString().Split(':')[1].Trim();
        }

        

        private void CbSelfDrive_Checked(object sender, RoutedEventArgs e)
        {
            if (cbSelfDrive.IsChecked == true)
            {
                cbDriver.IsChecked = false;
            }
            cbDriverName.Text = null;
        }
        private void CbDriver_Checked(object sender, RoutedEventArgs e)
        {
            if (cbDriver.IsChecked == true)
            {
                cbSelfDrive.IsChecked = false;
            }
            cbDriverName.Text = "Driver Name:";

        }
        private void CbMethodOfPaymentCredit_Checked(object sender, RoutedEventArgs e)
        {
            if (cbMethodOfPaymentCredit.IsChecked == true)
            {
                cbMethodOfPaymentCash.IsChecked = false;
            }
        }

        private void CbMethodOfPaymentCash_Checked(object sender, RoutedEventArgs e)
        {
            if (cbMethodOfPaymentCash.IsChecked == true)
            {
                cbMethodOfPaymentCredit.IsChecked = false;
            }
        }

        

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
         {
            string meth;
            if (cbMethodOfPaymentCash.IsChecked ==true )
            {
                meth = "Cash";
            }
            else { meth = "Credit"; }
            Reservation reservation = new Reservation()
            {

                BillingAddress = tbBillingAddress.Text,
                BookedAt = tbBookedAtDATE.SelectedDate,
                CarId = _db.Cars.Where(c=> c.CarMake == cbCarMake.SelectedItem.ToString()).Select(x=> x.CarId).SingleOrDefault(),
                MethodOfPayment = meth,
                Source = tbSource.Text,
                ReservationDateTime = DateTime.Now,
                StaffName =tbStaffName.Text,
                RentingStation= tbRentingStation.Text,                
            };
            _db.Reservations.Add(reservation);
            _db.SaveChanges();
            ReservationList.dataGrid.ItemsSource = _db.Reservations.ToList();
            this.Hide();
        }
        private void CbRentersName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var clientName= cbRentersName.SelectedValue.ToString();
            tbBillingAddress.Text = _db.Clients.Where(a => a.ClientName == clientName).Select(x => x.ClientPickUpAddress).SingleOrDefault();
            tbFlightNo.Text = _db.Clients.Where(a => a.ClientName == clientName).Select(x => x.ClientFlightNo).SingleOrDefault();
            tbTelephoneContact.Text = _db.Clients.Where(a => a.ClientName == clientName).Select(x => x.ClientContactNo).SingleOrDefault();
        }

    }
}
