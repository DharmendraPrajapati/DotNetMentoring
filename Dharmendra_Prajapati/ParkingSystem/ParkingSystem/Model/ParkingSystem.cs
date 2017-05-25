    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Model
{
    internal class ParkingSystem<T>
    {        
        public string ManagerName { get; set; }
        public IList<Floors<T>> Floors { get; set; }
    }
}
