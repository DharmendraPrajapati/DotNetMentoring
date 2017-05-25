using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModels
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime? CreatedUtc { get; set; }

        public DateTime? UpdatedUtc { get; set; }

        public string GetNameAndPhone()
        {
            return Name + Phone;
        }
    }

    public class CustomerViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
