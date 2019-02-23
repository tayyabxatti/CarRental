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
    /// Interaction logic for UpdateCar.xaml
    /// </summary>
    public partial class UpdateCar : Window
    {
        carRentEntities _db = new carRentEntities();
        int Id;
        public UpdateCar(int CarId)
        {
            InitializeComponent();
            Id = CarId;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Car updateCar = (from c in _db.Cars where c.CarId == Id select c).SingleOrDefault();
            tbCarFuelState.Text = updateCar.CarFuelState;
            tbCarKmIn.Text = updateCar.CarKmIn.ToString();
            tbCarKmOut.Text = updateCar.TimeOut.ToString();
            tbCarMake.Text = updateCar.CarMake;
            tbCarRegistrationNo.Text = updateCar.CarRegistrationNo;
            tbCompanyName.Text = updateCar.Company.CompanyName;
            _db.SaveChanges();
            Vehicle.dataGrid.ItemsSource = _db.Cars.ToList();
            this.Hide();
        }
    }
}
