using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class Response<T>
    {
        public T Object { get; set; }

        public bool IsCompleted { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
