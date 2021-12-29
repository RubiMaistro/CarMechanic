using CarMechanic_Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarMechanicOffice_Client.DataProviders
{
    class CustomerOrderDataProvider
    {
        private const string _url = "http://localhost:5000/api/customerorder";

        public static IEnumerable<CustomerOrder> GetCustomerOrders()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var orders = JsonConvert.DeserializeObject<IEnumerable<CustomerOrder>>(rawData);
                    return orders;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void CreateCustomerOrder(CustomerOrder order)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(order);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdateCustomerOrder(CustomerOrder order)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(order);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync($"{_url}/{order.Id}", content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void DeleteCustomerOrder(long id)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync($"{_url}/{id}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
