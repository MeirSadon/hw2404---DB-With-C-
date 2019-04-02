using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2703___Sql_In_Cs
{
    public class Customer
    {
        public Int64 ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public string Ph_Number { get; set; }

        public override string ToString()
        {
            return $"Employee ID: {ID}. Name: {FirstName} {LastName}. Age: {Age}. Address: {AddressCity}, {AddressStreet}. Phone Number: {Ph_Number}";
        }

        public override int GetHashCode()
        {
            return (int)this.ID;
        }
        static public bool operator ==(Customer c1, Customer c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
                return true;
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;
            if (ReferenceEquals(c1.ID, c2.ID))
                return true;
            else
            return false;
        }
        static public bool operator !=(Customer c1, Customer c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            Customer otherCustomer = obj as Customer;
            return (this.ID == otherCustomer.ID);
        }
    }
}
