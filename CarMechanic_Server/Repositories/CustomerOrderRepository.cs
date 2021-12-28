using CarMechanic_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMechanic_Server.Repositories
{
    public class CustomerOrderRepository
    {
        public static IList<CustomerOrder> GetCustomerOrders()
        {
            using (var database = new CustomerOrderContext())
            {
                var customerOrders = database.Orders.ToList();

                return customerOrders;
            }
        }

        public static CustomerOrder GetCustomerOrderById(long id)
        {
            using (var database = new CustomerOrderContext())
            {
                var customerOrder = database.Orders.Where(order => order.Id == id).FirstOrDefault();

                return customerOrder;
            }
        }

        public static void AddCustomerOrder(CustomerOrder customerOrder)
        {
            using (var database = new CustomerOrderContext())
            {
                database.Orders.Add(customerOrder);

                database.SaveChanges();
            }
        }

        public static void UpdateCustomerOrder(CustomerOrder customerOrder)
        {
            using (var database = new CustomerOrderContext())
            {
                database.Orders.Update(customerOrder);

                database.SaveChanges();
            }
        }

        public static void DeleteCustomerOrder(CustomerOrder customerOrder)
        {
            using (var database = new CustomerOrderContext())
            {
                database.Orders.Remove(customerOrder);

                database.SaveChanges();
            }
        }
    }
}
