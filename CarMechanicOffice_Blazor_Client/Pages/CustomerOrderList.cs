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

        public IList<CustomerOrder> Orders { get; set; }

        private bool IsSortedAscending;
        private string CurrentSortColumn;

        protected override async Task OnInitializedAsync()
        {
            Orders = await HttpClient.GetFromJsonAsync<CustomerOrder[]>("customerorder");
            SortTable("DateTime");
            await base.OnInitializedAsync();
        }

        private void SortTable(string columnName)
        {
            if (columnName != CurrentSortColumn)
            {
                Orders = Orders.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                CurrentSortColumn = columnName;
                IsSortedAscending = true;

            }
            else //Sorting against same column but in different direction
            {
                if (IsSortedAscending)
                {
                    Orders = Orders.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                else
                {
                    Orders = Orders.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }

                //Toggle this boolean
                IsSortedAscending = !IsSortedAscending;
            }
        }

        private string SetSortIcon(string columnName)
        {
            if (CurrentSortColumn != columnName)
            {
                return string.Empty;
            }
            if (IsSortedAscending)
            {
                return "fa-sort-down";
            }
            else
            {
                return "fa-sort-up";
            }
        }

    }
}
