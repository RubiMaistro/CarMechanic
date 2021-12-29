using CarMechanicOffice_Blazor_Client.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CarMechanicOffice_Blazor_Client.Pages
{
    public partial class CustomerOrderList
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public CustomerOrder[] Orders { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Orders = await HttpClient.GetFromJsonAsync<CustomerOrder[]>("customerorder"); 
            await base.OnInitializedAsync();
        }

    }
}
