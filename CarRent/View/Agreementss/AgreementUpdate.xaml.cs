﻿using System;
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

namespace CarRent.View.Agreementss
{
    /// <summary>
    /// Interaction logic for AgreementUpdate.xaml
    /// </summary>
    public partial class AgreementUpdate : Window
    {
        carRentEntities _db = new carRentEntities();
        int Id;
        public AgreementUpdate(int agreeId)
        {
            InitializeComponent();
            Id = agreeId;
            Load();
        }
        public void Load()
        {
            //like update 
            var views = (from r in _db.RentalAgreements where r.RentalAgreementId == Id select r).SingleOrDefault();
            var kmpkr = views.Reservation.Car.TotalKm * views.Reservation.Car.KmBill;
            var kpkr = views.Reservation.Car.TotalTime * views.Reservation.Car.TimeBill;
            tbInvoiceNo.Text = views.RentalAgreementId.ToString();
            tbBillingAddress.Text = views.Reservation.BillingAddress;
            tbCarName.Text = views.Reservation.Car.CarMake;
            tbCarRegistrationNo.Text = views.Reservation.Car.CarRegistrationNo;
            tbClientContactNo.Text = views.Reservation.Client.ClientContactNo;
            tbClientName.Text = views.Reservation.Client.ClientName;
            tbDateIn.Text = views.Reservation.Car.DateIn.ToString();
            tbDateOut.Text = views.Reservation.Car.DateOut.ToString();
            tbDriverName.Text = views.Reservation.Driver.DriverName.ToString();
            tbKmsDriven.Text = views.Reservation.Car.TotalKm.ToString();
            tbKmsIn.Text = views.Reservation.Car.CarKmIn.ToString();
            tbKmsOut.Text = views.Reservation.Car.CarKmOut.ToString();
            tbHr.Text = views.Reservation.Car.TotalTime.ToString();
            tbKms.Text = views.Reservation.Car.TotalKm.ToString();
            tbkmsRs.Text = kmpkr.ToString();
            tbhrRs.Text = kpkr.ToString();
            //DriverCharges
            tbGst.Text = views.GST.ToString();


            if (views.Reservation.MethodOfPayment == "Cash")
            {
                tbMethodOdPaymentCash.IsChecked = true;
                tbMehodOfPaymentCredit.IsChecked = false;
            }
            else
            {
                tbMethodOdPaymentCash.IsChecked = false;
                tbMehodOfPaymentCredit.IsChecked = true;
            }
            if (views.Reservation.Car.CarFuelState == "Full")
            {
                cbFuelStateFull.IsChecked = true;
                cbFuelStateHalf.IsChecked = false;
                cbFuelStateQuarter.IsChecked = false;
                cbFuelStateEmpty.IsChecked = false;
            }
            else if (views.Reservation.Car.CarFuelState == "Quarter")
            {
                cbFuelStateFull.IsChecked = false;
                cbFuelStateHalf.IsChecked = false;
                cbFuelStateQuarter.IsChecked = true;
                cbFuelStateEmpty.IsChecked = false;
            }
            else if (views.Reservation.Car.CarFuelState == "Half")
            {
                cbFuelStateFull.IsChecked = false;
                cbFuelStateHalf.IsChecked = true;
                cbFuelStateQuarter.IsChecked = false;
                cbFuelStateEmpty.IsChecked = false;
            }
            else
            {
                cbFuelStateFull.IsChecked = false;
                cbFuelStateHalf.IsChecked = false;
                cbFuelStateQuarter.IsChecked = false;
                cbFuelStateEmpty.IsChecked = true;
            }
            tbPickUpAddressOrFlightNo.Text = views.Reservation.Client.ClientPickUpAddress.ToString();
            tbReservationDateTime.Text = views.Reservation.ReservationDateTime.ToString();
            tbReservationNo.Text = views.Reservation.ReservationId.ToString();
            tbTimeIn.Text = views.Reservation.Car.TImeIn.ToString();
            tbTimeOut.Text = views.Reservation.Car.TimeOut.ToString();
            tbTimeUsed.Text = views.Reservation.Car.TotalTime.ToString();
        }

        private void BtnCalculateCharges_Click(object sender, RoutedEventArgs e)
        {
            if(tbFuel.Text =="")
            {
                tbFuel.Text = "0";
            }
            if (tbDriverNight.Text == "")
            {
                tbDriverNight.Text = "0";
            }
            if(tbPrepayment.Text=="")
            {
                tbPrepayment.Text = "0";
            }
            if (tbGst.Text == "")
            {
                tbGst.Text = "0";
            }
            if (tbToolTax.Text == "")
            {
                tbToolTax.Text = "0";
            }
            if (tbAmountDue.Text == "")
            {
                tbAmountDue.Text = "0";
            }

            if (tbDailyCharges.Text == "")
            {
                int subTotal = Convert.ToInt32(tbMonthlyCharges.Text) + Convert.ToInt32(tbhrRs.Text) + Convert.ToInt32(tbkmsRs.Text);
                int total = Convert.ToInt32(tbFuel.Text) + Convert.ToInt32(tbToolTax.Text) + Convert.ToInt32(tbDriverNight.Text);
                int grandTotal = Convert.ToInt32(tbPrepayment.Text) + Convert.ToInt32(tbAmountDue.Text);
                tbSubTotal.Text = subTotal.ToString();
                tbTotal.Text = (subTotal + total).ToString();
                tbGrandTotal.Text = (subTotal +total +grandTotal).ToString();
            }
            else if(tbMonthlyCharges.Text == "")
            {
                int subTotal = Convert.ToInt32(tbDailyCharges.Text) + Convert.ToInt32(tbhrRs.Text) + Convert.ToInt32(tbkmsRs.Text);
                int total = Convert.ToInt32(tbFuel.Text) + Convert.ToInt32(tbToolTax.Text) + Convert.ToInt32(tbDriverNight.Text);
                int grandTotal = Convert.ToInt32(tbPrepayment.Text) + Convert.ToInt32(tbAmountDue.Text);
                tbSubTotal.Text = subTotal.ToString();
                tbTotal.Text = (subTotal + total).ToString();
                tbGrandTotal.Text = (subTotal + total + grandTotal).ToString();
            }
        }

        private void BtnCloseRental_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
