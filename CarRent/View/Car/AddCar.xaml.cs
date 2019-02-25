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
            var totalKm = Int32.Parse(tbCarKmIn.Text) - Int32.Parse(tbCarKmOut.Text);
            var totalTime = tbTImeIn.Value - tbTimeOut.Value;
            
            Car car = new Car()
            {
                CarFuelState = tbCarFuelState.Text,
                CarKmIn = Int32.Parse(tbCarKmIn.Text),
                CarKmOut = Int32.Parse(tbCarKmOut.Text),
                CarMake = tbCarMake.Text,
                CarRegistrationNo = tbCarRegistrationNo.Text,
                DateIn = tbDateIn.SelectedDate,
                DateOut = tbDateOut.SelectedDate,
                KmBill = Int32.Parse(tbKmBill.Text),
                TImeIn = tbTImeIn.Value,
                TimeOut = tbTimeOut.Value,
                TimeBill = Int32.Parse(tbTimeBill.Text),
                TotalKm = totalKm,
                TotalTime = DateTime.Parse(totalTime.ToString()),
            };
            _db.Cars.Add(car);
            _db.SaveChanges();
            Vehicle.dataGrid.ItemsSource = _db.Cars.ToList();
            this.Hide();

        }
    }
}
