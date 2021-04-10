using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace best_edu_form
{
    class Account
    {
        public int id { get; set; }
        public string secondName { get; set; }
        public string firstName { get; set; }
        public string patronymic { get; set; }
        public string role { get; set; }
        public DateTime createdAt { get; set; }
        public string login { get; set; }
    }
}
