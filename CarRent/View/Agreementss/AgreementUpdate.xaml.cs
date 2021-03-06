﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
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
            tbDriverName.Text = views.Reservation.Driver.DriverName.ToString();
            tbHr.Text = views.Reservation.Car.TotalTime.ToString();
            tbKms.Text = views.Reservation.Car.TotalKm.ToString();
            tbkmsRs.Text = kmpkr.ToString();
            tbhrRs.Text = kpkr.ToString();
            //DriverCharges
            tbGst.Text = views.GST.ToString();
            tbActualItienrary.Text = views.AcutalItinerary;
            tbAmountDue.Text = views.AmountDue.ToString();
            tbFuel.Text = views.AgreementFuel.ToString();
            tbGrandTotal.Text = views.TotalCharges.ToString();


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
            if (views.AgreementClosed != "Closed")
            {
                tbTimeIn.Text = views.Reservation.Car.TImeIn.ToString();
                tbTimeOut.Text = views.Reservation.Car.TimeOut.ToString();
                tbTimeUsed.Text = views.Reservation.Car.TotalTime.ToString();
                tbDateIn.Text = views.Reservation.Car.DateIn.ToString();
                tbDateOut.Text = views.Reservation.Car.DateOut.ToString();
                tbKmsDriven.Text = views.Reservation.Car.TotalKm.ToString();
                tbKmsIn.Text = views.Reservation.Car.CarKmIn.ToString();
                tbKmsOut.Text = views.Reservation.Car.CarKmOut.ToString();
            }
            else
            {
                tbTimeIn.Text = views.AgreementTimeIn.ToString();
                tbTimeOut.Text = views.AgreementTimeOut.ToString();
                tbTimeUsed.Text = views.AgreementTotalTime.ToString();
                tbDateIn.Text = views.AgreementDateIn.ToString();
                tbDateOut.Text = views.AgreementDateOut.ToString();
                tbKmsDriven.Text = views.AgreementTotalKm.ToString();
                tbKmsIn.Text = views.AgreementKmIn.ToString();
                tbKmsOut.Text = views.AgreementKmOut.ToString();

            }

        }

        private void BtnCalculateCharges_Click(object sender, RoutedEventArgs e)
        {
            if (tbFuel.Text == "")
            {
                tbFuel.Text = "0";
            }
            if (tbDriverNight.Text == "")
            {
                tbDriverNight.Text = "0";
            }
            if (tbPrepayment.Text == "")
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
                tbGrandTotal.Text = (subTotal + total + grandTotal).ToString();

            }
            else if (tbMonthlyCharges.Text == "")
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
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to close this Rental?", "Close Rental", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var views = (from r in _db.RentalAgreements where r.RentalAgreementId == Id select r).SingleOrDefault();
                views.AgreementClosed = "Closed";
                views.HPkr = Convert.ToInt32(tbhrRs.Text);
                views.KPkr = Convert.ToInt32(tbkmsRs.Text);
                views.GST = Convert.ToInt32(tbGst.Text);
                views.AgreementFuel = Convert.ToInt32(tbFuel.Text);
                views.TollTaxCharges = Convert.ToInt32(tbToolTax.Text);
                views.DriverCharges = Convert.ToInt32(tbDriverNight.Text);
                views.PrePaymen = Convert.ToInt32(tbPrepayment.Text);
                views.AmountDue = Convert.ToInt32(tbAmountDue.Text);
                views.TotalCharges = Convert.ToInt32(tbGrandTotal.Text);
                views.AcutalItinerary = tbActualItienrary.Text;
                views.AgreementDateIn = tbDateIn.Text;
                views.AgreementDateOut = tbDateOut.Text;
                views.AgreementTimeIn = tbTimeIn.Text;
                views.AgreementTimeOut = tbTimeOut.Text;
                views.AgreementKmOut = Convert.ToInt32(tbKmsOut.Text);
                views.AgreementKmIn = Convert.ToInt32(tbKmsIn.Text);
                views.AgreementTotalKm = Convert.ToInt32(tbKms.Text);
                views.AgreementTotalTime = Convert.ToInt32(tbHr.Text);
                views.Reservation.Car.CarKmIn = Convert.ToInt32(tbKmsOut.Text);
                views.Reservation.Car.DateIn = tbDateOut.Text;
                views.Reservation.Car.TImeIn = tbTimeOut.Text;

                _db.SaveChanges();

            }
        }

        private void TbKmsDriven_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var views = (from r in _db.RentalAgreements where r.RentalAgreementId == Id select r).SingleOrDefault();
            var totalKm = Int32.Parse(tbKmsIn.Text) - Int32.Parse(tbKmsOut.Text);
            tbKmsDriven.Text = totalKm.ToString();
        }

        private void TbTimeUsed_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var totalTime = DateTime.Parse(tbTimeIn.Text) - DateTime.Parse(tbTimeOut.Text);
            tbTimeUsed.Text = totalTime.Hours.ToString();
        }

        private void TbTotalDays_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var totalDays = DateTime.Parse(tbDateOut.Text) - DateTime.Parse(tbDateIn.Text);
            tbTotalDays.Text = totalDays.Days.ToString();
        }
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var views = (from r in _db.RentalAgreements where r.RentalAgreementId == Id select r).SingleOrDefault();


            var PdfDOcument = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
            string path = $"d:\\name.pdf";
            PdfWriter.GetInstance(PdfDOcument, new FileStream(path, FileMode.OpenOrCreate));
            PdfDOcument.Open();
            //var imagePath = "";
            var spaceer = new iTextSharp.text.Paragraph("")
            {
                SpacingBefore = 10f,
                SpacingAfter = 10f,
            };
            PdfDOcument.Add(spaceer);

            var headerTable = new PdfPTable(new[] { .75f, 2f })
            {
                HorizontalAlignment = Convert.ToInt32(Left),
                WidthPercentage = 75,
                DefaultCell = { MinimumHeight = 22f }

            };
            headerTable.AddCell("CarMake");
            headerTable.AddCell(views.Reservation.Car.CarMake);
            headerTable.AddCell("CarModel");
            headerTable.AddCell(views.Reservation.Car.CarRegistrationNo);
            PdfDOcument.Add(headerTable);
            PdfDOcument.Add(spaceer);
            PdfDOcument.Close();
        }

    }
}
