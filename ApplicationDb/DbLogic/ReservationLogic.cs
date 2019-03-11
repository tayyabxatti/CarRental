using Common.Model;
using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDb.DbLogic
{
    public class ReservationLogic: BaseLogic
    {
        public static Response<bool> AddOrUpdate(ReservationVM reservationVM, bool isUpdate = false)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                Reservation reservation = null;
                if (isUpdate)
                    reservation = _db.Reservations.SingleOrDefault(c => c.Id == reservationVM.Id);

                if (reservation == null)
                    reservation = new Reservation();

                reservation.Booking_Time = reservationVM.Booking_Time;
                reservation.Modified_Time = DateTime.Now;
                reservation.Pick_Up_Address = reservationVM.Pick_Up_Address;
                reservation.Reserved_By = reservationVM.Reserved_By;
                if (!isUpdate)
                    _db.Reservations.Add(reservation);

                _db.SaveChanges();

                response.Object = true;
                response.IsCompleted = true;
                response.Message = "Reservation Successfully Added/Updated!";
            }
            catch (Exception ex)
            {
                response.Object = false;
                response.IsCompleted = false;
                response.Message = ex.Message;
                response.Exception = ex;
            }
            return response;
        }
        public static Response<ReservationVM> Get(int id)
        {
            Response<ReservationVM> response = new Response<ReservationVM>();
            try
            {
                response.Object = _db.Reservations
                                     .Where(c => c.Id == id)
                                     .Select(c => new ReservationVM()
                                     {
                                         Reserved_By = c.Reserved_By,
                                         Pick_Up_Address = c.Pick_Up_Address,
                                         Modified_Time=c.Modified_Time,
                                         Booking_Time=c.Booking_Time,
                                     }).FirstOrDefault();
                response.IsCompleted = true;
            }
            catch (Exception ex)
            {
                response.IsCompleted = false;
                response.Message = ex.Message;
                response.Exception = ex;
            }
            return response;
        }
        public static Response<List<ReservationVM>> List()
        {
            Response<List<ReservationVM>> response = new Response<List<ReservationVM>>();
            try
            {
                response.Object = _db.Reservations
                                     .Select(c => new ReservationVM
                                     {
                                         Booking_Time =c.Booking_Time,
                                         Modified_Time= c.Modified_Time,
                                         Pick_Up_Address = c.Pick_Up_Address,
                                         Reserved_By = c.Reserved_By,
                                     }).ToList();

                response.IsCompleted = true;
            }
            catch (Exception ex)
            {
                response.IsCompleted = false;
                response.Message = ex.Message;
                response.Exception = ex;
            }
            return response;
        }
        public static Response<ReservationVM> Delete(ReservationVM reservationVM)
        {
            Response<ReservationVM> response = new Response<ReservationVM>();
            try
            {
                var deleteReservation = _db.Reservations.Where(c => c.Id == reservationVM.Id).SingleOrDefault();
                _db.Reservations.Remove(deleteReservation);
                _db.SaveChanges();
                
                response.IsCompleted = true;

            }
            catch (Exception ex)
            {
                response.IsCompleted = false;
                response.Message = ex.Message;
                response.Exception = ex;
            }
            return response;
        }
    }
}
