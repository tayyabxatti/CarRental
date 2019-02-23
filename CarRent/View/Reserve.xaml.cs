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
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            string meth;
            if (cbMethodOfPaymentCash.IsChecked ==true )
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
                CheckOut =tbCheckOutDate.SelectedDate,
                ClientName = tbRentersName.Text,
                ClientContactNo = tbTelephoneContact.Text,
                ClientFlightNo = tbFlightNo.Text,
                ClientPickUpAddress = tbPickupAddress.Text,
                MethodOfPayment = meth,
                Source = tbSource.Text,
                ReservationDateTime = tbReservationDate.SelectedDate,
                StaffName =tbStaffName.Text,
                RentingStation= tbRentingStation.Text,
            };
            _db.Cars.Add(car);
            _db.SaveChanges();
            _db.Reservations.Add(reservation);
            _db.SaveChanges();

        }
    }
}
