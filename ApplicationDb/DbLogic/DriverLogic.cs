using Common.Model;
using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDb.DbLogic
{
    public class DriverLogic : BaseLogic
    {
        public static Response<bool> AddOrUpdate(DriverVM driverVM, bool isUpdate = false)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                Driver driver = null;
                if (isUpdate)
                    driver = _db.Drivers.SingleOrDefault(c => c.Id == driverVM.Id);

                if (driver == null)
                    driver = new Driver();

                driver.Name = driverVM.Name;

                if (!isUpdate)
                    _db.Drivers.Add(driver);

                _db.SaveChanges();

                response.Object = true;
                response.IsCompleted = true;
                response.Message = "Driver Successfully Added/Updated!";
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
        public static Response<DriverVM> Get(int id)
        {
            Response<DriverVM> response = new Response<DriverVM>();
            try
            {
                response.Object = _db.Drivers
                                     .Where(c => c.Id == id)
                                     .Select(c=> new DriverVM()
                                     {
                                         Id = c.Id,
                                         Name = c.Name
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
        public static Response<List<DriverVM>> List()
        {
            Response<List<DriverVM>> response = new Response<List<DriverVM>>();
            try
            {
                response.Object = _db.Drivers
                                     .Select(c => new DriverVM()
                                     {
                                         Id = c.Id,
                                         Name = c.Name
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
        public static Response<DriverVM> Delete(DriverVM driverVM)
        {
            Response<DriverVM> response = new Response<DriverVM>();
            try
            {
                var deleteDriver = _db.Drivers.Where(c => c.Id == driverVM.Id).SingleOrDefault();
                _db.Drivers.Remove(deleteDriver);
                _db.SaveChanges();

                
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
    }
}
