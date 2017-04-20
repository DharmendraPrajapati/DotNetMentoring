using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    public class PersonClass : IEquatable<PersonClass>
    {
        private string uniqueSsn;
        private string lName;

        public PersonClass(string lastName, string ssn)
        {
            this.uniqueSsn = ssn;
            this.LastName = lastName;
        }

        public string SSN
        {
            get { return this.uniqueSsn; }
        }

        public string LastName
        {
            get { return this.lName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("The last name cannot be null or empty.");
                else
                    this.lName = value;
            }
        }

        public bool Equals(PersonClass other)
        {
            if (other == null)
                return false;

            if (this.uniqueSsn == other.uniqueSsn)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            PersonClass personObj = obj as PersonClass;
            if (personObj == null)
                return false;
            else
                return Equals(personObj);
        }

        public override int GetHashCode()
        {
            return this.SSN.GetHashCode();
        }

        public static bool operator ==(PersonClass person1, PersonClass person2)
        {
            if (((object)person1) == null || ((object)person2) == null)
                return Object.Equals(person1, person2);

            return person1.Equals(person2);
        }

        public static bool operator !=(PersonClass person1, PersonClass person2)
        {
            if (((object)person1) == null || ((object)person2) == null)
                return !Object.Equals(person1, person2);

            return !(person1.Equals(person2));
        }
    }
    class Program
    {
        
    }
}
