using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2703___Sql_In_Cs
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerDAO dao = new CustomerDAO();

            dao.GetAllCustomers();

            Customer c = new Customer
            {
                ID = 1,
                FirstName = "Ronen",
                LastName = "Haim",
                Age = 33,
                AddressCity = "Rishon le zion",
                AddressStreet = "Hertzel",
                Ph_Number = "3-97644196"
            };
            Customer c4 = new Customer
            {
                ID = 1,
                FirstName = "Ronen",
                LastName = "Haim",
                Age = 33,
                AddressCity = "Rishon le zion",
                AddressStreet = "Hertzel",
                Ph_Number = "4766634196"
            };

            //dao.AddCustomer(c4);


           dao.UpdateCustomer(1, c);
           
           
           List<Customer> allCustomers = dao.GetAllCustomers();
           allCustomers.ForEach(cs => Console.WriteLine(cs));
           
           //dao.DeleteCustomer(10);
           //dao.DeleteCustomer(100);
           
           List<Customer> customers = dao.GetAllCustomers();
           customers.ForEach(cs => Console.WriteLine(cs));

            
            Console.WriteLine(dao.GetCustomerByIdLinq(12));

            Console.WriteLine(dao.GetCustomerByPhoneNumber("3-9644196"););

            List<Customer> customersAges = dao.GetCustomersBetweenAges(30, 35);
            customersAges.ForEach(cs => Console.WriteLine(cs));


            List<Customer> customersCity = dao.GetCustomersByLivingCity("Rishon le zion");
            customersCity.ForEach(cs => Console.WriteLine(cs));

            //dao.RemoveAllCustomers();

            List<Customer> customers2 = dao.GetAllCustomers();
            customers2.ForEach(cs => Console.WriteLine(cs));

            dao.Close();
        }
    }
}
