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
            Load();
        }
        public void Load()
        {
            var updateCar = (from c in _db.Cars where c.CarId == Id select c).SingleOrDefault();
            var updateCompany = (from c in _db.Companies where c.CompanyId == updateCar.CompanyId select c).SingleOrDefault();
            var updateDriver = (from d in _db.Drivers where d.DriverId == updateCar.DriverId select d).SingleOrDefault();
            if (updateCompany.CompanyName != null)
            {
                tbCompanyName.Text = updateCompany.CompanyName;
            }
            if (updateDriver.DriverName !=null) {
                tbDriverName.Text = updateDriver.DriverName;
            }
              tbCarFuelState.Text =updateCar.CarFuelState;
               tbCarKmIn.Text = updateCar.CarKmIn.ToString(); 
               tbCarKmOut.Text =updateCar.CarKmOut.ToString();
               tbCarMake.Text = updateCar.CarMake;    
               tbCarRegistrationNo.Text=updateCar.CarRegistrationNo;    
               tbDateIn.SelectedDate = updateCar.DateIn;    
               tbDateOut.SelectedDate = updateCar.DateOut;    
               tbKmBill.Text = updateCar.KmBill.ToString();
               tbTImeIn.Value = updateCar.TImeIn;    
               tbTimeOut.Value = updateCar.TimeOut;   
               tbTimeBill.Text = updateCar.TimeBill.ToString();
               tbTotalKm.Text = updateCar.TotalKm.ToString();
            tbTotalTime.Text=updateCar.TotalTime.ToString();     

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
