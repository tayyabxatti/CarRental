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
    /// Interaction logic for UpdateReservation.xaml
    /// </summary>
    public partial class UpdateReservation : Window
    {
        carRentEntities _db = new carRentEntities();
        int Id;
        public UpdateReservation(int ReservationId)
        {
            InitializeComponent();
            Id = ReservationId;
            Load();
        }

        public void Load()
        {
            Reservation updateReservation = (from r in _db.Reservations where r.ReservationId == Id select r).SingleOrDefault();
            
            tbBillingAddress.Text = updateReservation.BillingAddress;
            tbBookedAtDATE.SelectedDate = updateReservation.BookedAt;
            tbRentersName.Text = updateReservation.Client.ClientName;
            tbTelephoneContact.Text = updateReservation.Client.ClientContactNo;
            tbFlightNo.Text = updateReservation.Client.ClientFlightNo;
            tbPickupAddress.Text = updateReservation.Client.ClientPickUpAddress;
            tbSource.Text = updateReservation.Source;
            tbReservationDate.SelectedDate = updateReservation.ReservationDateTime;
            tbStaffName.Text = updateReservation.StaffName;
            tbRentingStation.Text = updateReservation.RentingStation;
            tbCarMake.Text = updateReservation.Car.CarMake;
            tbCarRegistrationNo.Text = updateReservation.Car.CarRegistrationNo;
            tbDriverName.Text = updateReservation.Car.Driver.DriverName;
            tbRentersName.Text = updateReservation.Client.ClientName;

            //check in station and Renter's name remaining.

            if (updateReservation.MethodOfPayment=="cash")
            {
                cbMethodOfPaymentCash.IsChecked = true ;
            }
            else
            {
                cbMethodOfPaymentCredit.IsChecked = true;
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Reservation updateReservation = (from r in _db.Reservations where r.ReservationId == Id select r).SingleOrDefault();
            Client updateClient = (from c in _db.Clients where c.ClientId == updateReservation.ClientId select c).SingleOrDefault();
            Driver updateDriver = (from d in _db.Drivers where d.DriverId == updateReservation.ReservationId select d).SingleOrDefault();
            Car updateCar = (from c in _db.Cars where c.CarId == updateReservation.CarId select c).SingleOrDefault();
            string meth;
            if (cbMethodOfPaymentCash.IsChecked == true)
            {
                meth = "Cash";
            }
            else { meth = "Credit"; }
            updateDriver.DriverName = tbDriverName.Text;
            _db.SaveChanges();
            updateCar.CarMake = tbCarMake.Text;
            updateCar.CarRegistrationNo = tbCarRegistrationNo.Text;
            _db.SaveChanges();
            updateClient.ClientName = tbRentersName.Text;
            updateClient.ClientContactNo = tbTelephoneContact.Text;
            updateClient.ClientFlightNo = tbFlightNo.Text;
            updateClient.ClientPickUpAddress = tbPickupAddress.Text;
            _db.SaveChanges();
            updateReservation.BillingAddress = tbBillingAddress.Text;
             updateReservation.BookedAt = tbBookedAtDATE.SelectedDate;
             updateReservation.MethodOfPayment = meth;
             updateReservation.Source = tbSource.Text;
             updateReservation.ReservationDateTime = tbReservationDate.SelectedDate;
             updateReservation.StaffName = tbStaffName.Text;
             updateReservation.RentingStation = tbRentingStation.Text;
            _db.SaveChanges();
            ReservationList.dataGrid.ItemsSource = _db.Reservations.ToList();
            this.Hide();
        }
    }
}
