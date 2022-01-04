﻿using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarMechanic_Common.Models;

namespace CarMechanicOffice_Blazor_Client.Pages
{
    public partial class CustomerOrderEdit
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string CustomerOrderId { get; set; }

        public CustomerOrder CustomerOrder { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CustomerOrder = await HttpClient.GetFromJsonAsync<CustomerOrder>($"customerorder/{CustomerOrderId}");
            await base.OnInitializedAsync();
        }

        private async Task EditCustomerOrder()
        {
            await HttpClient.PutAsJsonAsync($"customerorder/{CustomerOrderId}", CustomerOrder);
            NavigationManager.NavigateTo($"order/{CustomerOrderId}");
        }

        private async Task DeleteCustomerOrder()
        {
            await HttpClient.DeleteAsync($"customerorder/{CustomerOrderId}");
            NavigationManager.NavigateTo("customerorders");
        }
    }
}
