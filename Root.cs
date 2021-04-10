using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace best_edu_form
{
    class Root<T>
    {
        public string type { get; set; }
        public T data { get; set; }
        public bool isSuccess { get; set; }
    }
}
