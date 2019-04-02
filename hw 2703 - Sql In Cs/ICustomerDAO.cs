using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2703___Sql_In_Cs
{
    interface ICustomerDAO
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer c);
        void CreateTable();
        void UpdateCustomer(int id, Customer c);
        void DeleteCustomer(int id);
        List<Customer> GetCustomersByLivingCity(string city);
        List<Customer> GetCustomersBetweenAges(int minAge, int maxAge);
        Customer GetCustomerByPhoneNumber(string nPhone);
        void RemoveAllCustomers();

    }
}
