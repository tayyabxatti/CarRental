using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class ClientVM
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public string Billing_Address { get; set; }
        public string Phone_Number { get; set; }
        public string Company_Name { get; set; }
        public string Company_Contact_Number { get; set; }
    }
}
