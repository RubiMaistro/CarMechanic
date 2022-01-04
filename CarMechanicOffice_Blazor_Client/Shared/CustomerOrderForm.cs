using CarMechanic_Common.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMechanicOffice_Blazor_Client.Shared
{
    public partial class CustomerOrderForm
    {
        [Parameter]
        public CustomerOrder CustomerOrder { get; set; }

        [Parameter]
        public Func<Task> SubmitForm { get; set; }
    
        [Parameter]
        public string ButtonTitle { get; set; }
    }
}
