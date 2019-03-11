using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModel;

namespace ApplicationDb.DbLogic
{
    public class CarLogic : BaseLogic
    {
        public static Response<bool> AddOrUpdate(CarVM carVM, bool isUpdate = false)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                Car car = null;
                if (isUpdate)
                    car = _db.Cars.SingleOrDefault(c => c.Id == carVM.Id);

                if (car == null)
                    car = new Car();

                car.Make = carVM.Make;
                car.Model = carVM.Model;
                car.Registration_Number = carVM.RegistrationNo;
                //car.Car_Owner_Id = carVM.CarOwnerVM.Id;
                if (!isUpdate)
                    _db.Cars.Add(car);

                _db.SaveChanges();

                response.Object = true;
                response.IsCompleted = true;
                response.Message = "Car Successfully Added/Updated!";
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
        public static Response<CarVM> Get(int id)
        {
            Response<CarVM> response = new Response<CarVM>();
            try
            {
                response.Object = _db.Cars
                                     .Where(c => c.Id == id)
                                     .Select(c => new CarVM()
                                     {
                                         Id = c.Id,
                                         Make = c.Make,
                                         Model = c.Model,
                                         RegistrationNo= c.Registration_Number,
                                         
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
        public static Response<List<CarVM>> List()
        {
            Response<List<CarVM>> response = new Response<List<CarVM>>();
            try
            {
                response.Object = _db.Cars.Select(c => new CarVM
                {
                    Make = c.Make,
                    Model = c.Model,
                    RegistrationNo = c.Registration_Number,
                    Id = c.Id,
                }).ToList();
                response.IsCompleted = true;
           
            }
            catch(Exception ex)
            {
                response.IsCompleted = false;
                response.Message = ex.Message;
                response.Exception = ex;
            }
            return response;
        }
        public static Response<CarVM> Delete(CarVM carVM)
        {
            Response<CarVM> response = new Response<CarVM>();
            try
            {
                var deletecar = _db.Cars.Where(c => c.Id == carVM.Id).SingleOrDefault();
                _db.Cars.Remove(deletecar);
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
