using CarMechanicOffice_Blazor_Client.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CarMechanicOffice_Blazor_Client.Pages
{
    public partial class CustomerOrderAdd
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CustomerOrder CustomerOrder { get; set; } = new CustomerOrder();

        private async Task AddNewCustomerOrder()
        {
            CustomerOrder.DateTime = System.DateTime.Now;
            await HttpClient.PostAsJsonAsync("customerorder", CustomerOrder);
            NavigationManager.NavigateTo("customerorders");
        }
    }
}
