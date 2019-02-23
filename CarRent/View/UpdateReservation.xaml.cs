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
            tbCheckOutDate.SelectedDate = updateReservation.CheckOut;
            tbRentersName.Text = updateReservation.ClientName;
            tbTelephoneContact.Text = updateReservation.ClientContactNo;
            tbFlightNo.Text = updateReservation.ClientFlightNo;
            tbPickupAddress.Text = updateReservation.ClientPickUpAddress;
            tbSource.Text = updateReservation.Source;
            tbReservationDate.SelectedDate = updateReservation.ReservationDateTime;
            tbStaffName.Text = updateReservation.StaffName;
            tbRentingStation.Text = updateReservation.RentingStation;
            tbCarMake.Text = updateReservation.Car.CarMake;
            tbCarRegistrationNo.Text = updateReservation.Car.CarRegistrationNo;
            tbDriverName.Text = updateReservation.Car.DriverName;
            tbRentersName.Text = updateReservation.ClientName;

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
            string meth;
            if (cbMethodOfPaymentCash.IsChecked == true)
            {
                meth = "Cash";
            }
            else { meth = "Credit"; }

            Car car = new Car()
            {

                CarMake = tbCarMake.Text,
                CarRegistrationNo = tbCarRegistrationNo.Text,
                DriverName = tbDriverName.Text,
            };
            Reservation reservation = new Reservation()
            {

                BillingAddress = tbBillingAddress.Text,
                BookedAt = tbBookedAtDATE.SelectedDate,
                CarId = car.CarId,
                CheckOut = tbCheckOutDate.SelectedDate,
                ClientName = tbRentersName.Text,
                ClientContactNo = tbTelephoneContact.Text,
                ClientFlightNo = tbFlightNo.Text,
                ClientPickUpAddress = tbPickupAddress.Text,
                MethodOfPayment = meth,
                Source = tbSource.Text,
                ReservationDateTime = tbReservationDate.SelectedDate,
                StaffName = tbStaffName.Text,
                RentingStation = tbRentingStation.Text,
               
            };
            _db.Cars.Add(car);
            _db.SaveChanges();
            _db.Reservations.Add(reservation);
            _db.SaveChanges();
            ReservationList.dataGrid.ItemsSource = _db.Reservations.ToList();
            this.Hide();
        }
    }
}
