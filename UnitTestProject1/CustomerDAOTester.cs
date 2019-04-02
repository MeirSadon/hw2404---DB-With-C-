using System;
using hw_2703___Sql_In_Cs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SQLite;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class CustomerDAOTester
    {
        CustomerDAO dao = new CustomerDAO();

        Customer c = new Customer
        {
            ID = 1,
            FirstName = "Ronen",
            LastName = "Haim",
            Age = 33,
            AddressCity = "Rishon le zion",
            AddressStreet = "Hertzel",
            Ph_Number = "123123"
        };
        //[TestMethod]
        //[ExpectedException(typeof(SameCusomersException))]
        //public void AddCustomerWithSameException()
        //{
        //    dao.AddCustomer(c);
        //    dao.AddCustomer(c);
        //}
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullCustomerException()
        {
            CustomerDAO dao = new CustomerDAO();
            dao.AddCustomer(null);
        }
        [TestMethod]
        [ExpectedException(typeof(CustomerNotFoundException))]
        public void DeleteCustomerThatNotExist()
        {
            dao.DeleteCustomer(10000);
        }
    }
}
