using CarMechanic_Common.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CarMechanicOffice_Blazor_Client.Pages
{
    public partial class CustomerOrderInfo
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

    }
}
