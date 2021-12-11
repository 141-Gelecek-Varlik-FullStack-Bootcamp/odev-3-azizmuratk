using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysLowPrice.Model
{
    // Generic
    public class General<T>
    {
        public bool IsSuccess { get; set; }

        public T Entity { get; set; }
    }
}
