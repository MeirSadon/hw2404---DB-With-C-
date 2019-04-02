using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2703___Sql_In_Cs
{
    public class CustomerDAO : ICustomerDAO
    {
        static SQLiteConnection connection;

        public static string dbName = @"c:\meir\Customers.db";

        // *****   Constractor To Open Stream   *****
        public CustomerDAO()
        {
            connection = new SQLiteConnection($"Data Source = {dbName}; Version=3;");
            connection.Open();
        }
        
        // *****   Close Stream   *****
        public void Close()
        {
            connection.Close();
        }
        // *****   Create Table   *****
        public void CreateTable()
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"CREATE TABLE 'CUSTOMERS' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "'FIRST_NAME' TEXT NOT NULL," +
                    "'LAST_NAME' TEXT NOT NULL," +
                    "'AGE'   INTEGER NOT NULL," +
                    "'ADDRESS_CITY'  TEXT," +
                    "'ADDRESS_STREET'    TEXT," +
                    "'PH_NUMBER' TEXT UNIQUE)", connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // *****   Add Customer   *****
        public void AddCustomer(Customer c)
        {
            List<Customer> customers = GetAllCustomers();
            if (customers.Contains(c))
                throw new SameCusomersException("It's Same Customers");
            if (ReferenceEquals(c, null))
                throw new ArgumentNullException("It's Null Customer");
            using (SQLiteCommand cmd = new SQLiteCommand($"insert into customers('first_name','last_name', 'age', 'address_city', 'address_Street', 'ph_number')" +
            $" values('{c.FirstName}','{c.LastName}',{c.Age},'{c.AddressCity}','{c.AddressStreet}','{c.Ph_Number}')", connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // *****   Delete Customer   *****
        public void DeleteCustomer(int id)
        {
            Customer c = new Customer { ID = id, };
            List<Customer> customers = GetAllCustomers();
            foreach (Customer ca in customers)
            {
                if (ca.ID == c.ID)
                {
                    using (SQLiteCommand cmd = new SQLiteCommand($"delete FROM Customers WHERE ID = {id}", connection))
                    {
                        cmd.ExecuteNonQuery();
                        return;
                    }
                }
            }
            throw new CustomerNotFoundException("Customer Not Found at The List");
        }

        // *****   Get All Customers   *****
        public List<Customer> GetAllCustomers()
        {
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Customers", connection))
            {
                List<Customer> customers = new List<Customer>();
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read() == true)
                    {
                        Customer c = new Customer
                        {

                            ID = (Int64)reader["ID"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["Last_NAME"],
                            Age = (int)reader["AGE"],
                            AddressCity = (string)reader["Address_City"],
                            AddressStreet = (string)reader["Address_Street"],
                            Ph_Number = (string)reader["PH_NUMBER"],
                        };
                        customers.Add(c);
                    }
                    return customers;
                }
            }
        }

        // *****   Get Customer By Id   *****
        public Customer GetCustomerById(int id)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"Select * from customers where id = {id}", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() == true)
                    {
                        Customer c = new Customer
                        {
                            ID = (Int64)reader["ID"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["Last_NAME"],
                            Age = (int)reader["AGE"],
                            AddressCity = (string)reader["Address_City"],
                            AddressStreet = (string)reader["Address_Street"],
                            Ph_Number = (string)reader["PH_NUMBER"],
                        };
                        return c;
                    }
                }
            }
            return null;
        }

        // *****   Get Customers Between Ages   *****
        public List<Customer> GetCustomersBetweenAges(int minAge, int maxAge)
        {
            List<Customer> customers = new List<Customer>();
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * from customers WHERE age BETWEEN {minAge} and {maxAge}", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read() == true)
                    {
                        Customer c = new Customer
                        {
                            ID = (Int64)reader["ID"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["Last_NAME"],
                            Age = (int)reader["AGE"],
                            AddressCity = (string)reader["Address_City"],
                            AddressStreet = (string)reader["Address_Street"],
                            Ph_Number = (string)reader["PH_NUMBER"],
                        };
                        customers.Add(c);
                    }
                }
            }
            return customers;
        }

        // *****   Get Customer By Phone Number   *****
        public Customer GetCustomerByPhoneNumber(string phNumber)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"Select * from customers where PH_NUMBER = '{phNumber}'", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() == true)
                    {
                        Customer c = new Customer
                        {
                            ID = (Int64)reader["ID"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["Last_NAME"],
                            Age = (int)reader["AGE"],
                            AddressCity = (string)reader["Address_City"],
                            AddressStreet = (string)reader["Address_Street"],
                            Ph_Number = (string)reader["PH_NUMBER"],
                        };
                        return c;
                    }
                }
            }
            return null;
        }

        // *****   Get Customer By Living City   *****
        public List<Customer> GetCustomersByLivingCity(string city)
        {
            List<Customer> customers = new List<Customer>();
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * from customers WHERE Address_city = '{city}'", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read() == true)
                    {
                        Customer c = new Customer
                        {
                            ID = (Int64)reader["ID"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["Last_NAME"],
                            Age = (int)reader["AGE"],
                            AddressCity = (string)reader["Address_City"],
                            AddressStreet = (string)reader["Address_Street"],
                            Ph_Number = (string)reader["PH_NUMBER"],
                        };
                        customers.Add(c);
                    }
                }
            }
            return customers;
        }

        // *****   Remove All Customers   *****
        public void RemoveAllCustomers()
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"delete FROM Customers", connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // *****   Update Customer   *****
        public void UpdateCustomer(int id, Customer c)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"UPDATE CUSTOMERs SET ID={c.ID}, FIRST_NAME='{c.FirstName}'," +
                $"LAST_NAME='{c.LastName}', AGE={c.Age}, ADDRESS_CITY='{c.AddressCity}', ADDRESS_STREET='{c.AddressStreet}'," +
                $"PH_NUMBER='{c.Ph_Number}' WHERE ID ={id}", connection))
            {
                cmd.ExecuteNonQuery();
            }
        }



                    /*
                     * LINQ Functions.
                     */

       

        // *****   Get Customer By Id With LINQ   *****
        public Customer GetCustomerByIdLinq(int ida)
        {
            List<Customer> customers = GetAllCustomers();
            var byId = (from cusId in customers
                        where cusId.ID == ida
                        select cusId).ToList();
            if (byId.Count > 0)
            {
                Customer returnCustomer = byId[0];
                return returnCustomer;
            }
            else throw new CustomerNotFoundException("Customer Not Found!");
        }

        // *****   Get Customers Between Ages With LINQ   *****
        public List<Customer> GetCustomersBetweenAgesLinq(int minAge, int maxAge)
        {
            List<Customer> customers = GetAllCustomers();
            var betweenAges = (from cusAges in customers
                               where cusAges.Age > minAge && cusAges.Age < maxAge
                               select cusAges).ToList();
            if (betweenAges.Count > 0)
            {
                //betweenAges.ForEach(c => Console.WriteLine(c));
                    return betweenAges;
            }
            else throw new CustomerNotFoundException("Customer Not Found!");
        }

        // *****   Get Customer By Phone Number With LINQ   *****
        public Customer GetCustomerByPhoneNumberLinq(string phNumber)
        {
            List<Customer> customers = GetAllCustomers();
            var byPhone = (from cusPhone in customers
                           where cusPhone.Ph_Number == phNumber
                           select cusPhone).ToList();
            if (byPhone.Count > 0)
            {
                Customer returnCustomer = byPhone[0];
                return returnCustomer;
            }
            else throw new CustomerNotFoundException("Customer Not Found!");
        }

        // *****   Get Customer By Living City With LINQ   *****
        public List<Customer> GetCustomersByLivingCityLinq(string city)
        {
            List<Customer> customers = GetAllCustomers();
            var byCity = (from cusCity in customers
                           where cusCity.AddressCity == city
                           select cusCity).ToList();
            if (byCity.Count > 0)
            {
                return byCity;
            }
            else throw new CustomerNotFoundException("Customer Not Found!");
        }
    }
}



