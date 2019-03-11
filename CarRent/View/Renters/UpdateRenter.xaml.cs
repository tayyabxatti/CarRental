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
    /// Interaction logic for UpdateRenter.xaml
    /// </summary>
    public partial class UpdateRenter : Window
    {
        carRentEntities _db = new carRentEntities();
        int _Id;
        public UpdateRenter(int clientId)
        {
            InitializeComponent();
            _Id = clientId;
            Load();
        }

        public void Load()
        {
            var listresponce = ClientLogic.Get(_Id);
            if(listresponce.IsCompleted && listresponce.Object != null)
            {
                tbClientCompanyName.Text = listresponce.Object.Company_Name;
                tbClientContactNo.Text = listresponce.Object.Phone_Number;
                tbClientName.Text = listresponce.Object.Name;
                
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var responce = ClientLogic.AddOrUpdate(new Common.ViewModel.ClientVM
            {
                Name = tbClientName.Text,
                Company_Name = tbClientCompanyName.Text,
                Phone_Number = tbClientContactNo.Text,
            }, true);

            if (responce.IsCompleted)
            {
                var listResponse = ClientLogic.List();
                if (listResponse.IsCompleted)
                    RenterMenu.dataGrid.ItemsSource = listResponse.Object;
                this.Hide();
            }
            //var updateClient = _db.Clients.Where(d => d.ClientId == Id).SingleOrDefault();
            //updateClient.ClientName = tbClientName.Text;
            //updateClient.ClientPickUpAddress =  tbClientPickUpAddress.Text;
            //updateClient.ClientCompanyName = tbClientCompanyName.Text;
            //updateClient.ClientContactNo = tbClientContactNo.Text;
            //_db.SaveChanges();

        }
    }
}
