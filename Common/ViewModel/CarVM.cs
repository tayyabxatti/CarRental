using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class CarVM
    {
        public int Id { set; get; }
        public string Make { set; get; }
        public string Model { set; get; }
        public string RegistrationNo { set; get; }
        public CarOwnerVM CarOwnerVM { set; get; }
    }
}
