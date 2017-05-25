using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeStructure
{
   public class Father:Person
    {
        private char _gender;

        public Father(char gender)
        {
            _gender = gender;
        }

        public new char Gender
        {
            get { return  'M'; }
            
        }

    }
}
