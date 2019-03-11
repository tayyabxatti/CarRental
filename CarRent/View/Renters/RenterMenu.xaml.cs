using ApplicationDb.DbLogic;
using Common.ViewModel;
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

namespace CarRent.View.Renters
{
    /// <summary>
    /// Interaction logic for RenterMenu.xaml
    /// </summary>
    public partial class RenterMenu : UserControl
    {
        carRentEntities _db = new carRentEntities();
        public static DataGrid dataGrid;
        public RenterMenu()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            ClientGrid.ItemsSource = ClientLogic.List().Object;
            dataGrid = ClientGrid;  

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int Id = (ClientGrid.SelectedItem as ClientVM).Id;
            UpdateRenter updateRenter = new UpdateRenter(Id);
            updateRenter.ShowDialog();

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int selectedId = (ClientGrid.SelectedItem as ClientVM).Id;
            var responce = ClientLogic.Delete(new ClientVM
            {
                Id = selectedId,
            });
            if (responce.IsCompleted)
            {
                ClientGrid.ItemsSource = ClientLogic.List().Object;
            }
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            AddRenter addRenter = new AddRenter();
            addRenter.ShowDialog();

        }
    }

}
