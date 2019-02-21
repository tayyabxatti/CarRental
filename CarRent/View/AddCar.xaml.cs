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
            var totalKm = Int32.Parse(tbCarKmIn.Text) - Int32.Parse(tbCarKmOut.Text);
            var totalTime = DateTime.Parse(tbTImeIn.Text) - DateTime.Parse(tbTimeOut.Text);
            Car car = new Car()
            {
                CarFuelState = tbCarFuelState.Text,
                CarKmIn = Int32.Parse(tbCarKmIn.Text),
                CarKmOut = Int32.Parse(tbCarKmOut.Text),
                CarMake = tbCarMake.Text,
                CarRegistrationNo = tbCarRegistrationNo.Text,
                CompanyName = tbCompanyName.Text,
                DateIn = tbDateIn.SelectedDate,
                DateOut = tbDateOut.SelectedDate,
                DriverName = tbDriverName.Text,
                KmBill = Int32.Parse(tbKmBill.Text),
                TImeIn = DateTime.Parse(tbTImeIn.Text),
                TimeOut = DateTime.Parse(tbTimeOut.Text),
                TimeBill = Int32.Parse(tbTimeBill.Text),
                TotalKm = totalKm,
                
            };
            _db.Cars.Add(car);
            _db.SaveChanges();
        }
    }
}
