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

namespace CarRent.View.Renters
{
    /// <summary>
    /// Interaction logic for AddRenter.xaml
    /// </summary>
    public partial class AddRenter : Window
    {
        carRentEntities _db = new carRentEntities(); 

        public AddRenter()
        {
            InitializeComponent();
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            var responce = ClientLogic.AddOrUpdate(new Common.ViewModel.ClientVM
            {
                Name = tbClientName.Text,
                Company_Name = tbClientCompanyName.Text,
                Phone_Number = tbClientContactNo.Text,


            });
            if (responce.IsCompleted)
            {
                var listresponce = ClientLogic.List();
                if (listresponce.IsCompleted)
                {
                    RenterMenu.dataGrid.ItemsSource = listresponce.Object;
                    this.Hide();
                }

            }

            //Client client = new Client()
            //{
            //    ClientName = tbClientName.Text,
            //    ClientCompanyName = tbClientCompanyName.Text,
            //    ClientContactNo = tbClientContactNo.Text,
            //    ClientPickUpAddress = tbClientPickUpAddress.Text,
            //};
            //_db.Clients.Add(client);
            //_db.SaveChanges();

        }
    }
}
