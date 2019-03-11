using Common.Model;
using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDb.DbLogic
{
    public class ClientLogic : BaseLogic
    {
        public static Response<bool> AddOrUpdate(ClientVM clientVM, bool isUpdate = false)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                Client client = null;
                if (isUpdate)
                    client = _db.Clients.SingleOrDefault(c => c.Id == clientVM.Id);

                if (client == null)
                    client = new Client();

                client.Name = clientVM.Name;
                client.Phone_Number = clientVM.Phone_Number;
                client.Company_Name = clientVM.Company_Name;
                client.Company_Contact_Numer = clientVM.Company_Contact_Number;
                client.Billing_Address = clientVM.Billing_Address;
                if (!isUpdate)
                    _db.Clients.Add(client);

                _db.SaveChanges();

                response.Object = true;
                response.IsCompleted = true;
                response.Message = "Client Successfully Added/Updated!";
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
        public static Response<ClientVM> Get(int id)
        {
            Response<ClientVM> response = new Response<ClientVM>();
            try
            {
                response.Object = _db.Clients
                                     .Where(c => c.Id == id)
                                     .Select(c => new ClientVM()
                                     {
                                         Billing_Address = c.Billing_Address,
                                         Company_Contact_Number = c.Company_Contact_Numer,
                                         Company_Name = c.Company_Name,
                                         Name = c.Name,
                                          Id = c.Id,
                                          Phone_Number = c.Phone_Number,
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
        public static Response<List<ClientVM>> List()
        {
            Response<List<ClientVM>> response = new Response<List<ClientVM>>();
            try
            {
                response.Object = _db.Clients.Select(c => new ClientVM
                {
                    Phone_Number= c.Phone_Number,
                    Name=c.Name,
                    Id=c.Id,
                    Company_Name=c.Company_Name,
                    Company_Contact_Number=c.Company_Name,
                    Billing_Address= c.Billing_Address,
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
        public static Response<ClientVM> Delete(ClientVM clientVM)
        {
            Response<ClientVM> response = new Response<ClientVM>();
            try
            {
                var deleteclient = _db.Clients.Where(c => c.Id == clientVM.Id).SingleOrDefault();
                _db.Clients.Remove(deleteclient);
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
