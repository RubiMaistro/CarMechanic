using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMechanicOffice_Blazor_Client.Models
{
    public class CustomerOrder
    {
        public enum CarWorkStatus
        {
            Recorded,
            InProgress,
            Finished
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarModel { get; set; }
        public string CarLicencePlateNumber { get; set; }
        public string CarProblemDescription { get; set; }
        public DateTime DateTime { get; set; }
        public CarWorkStatus WorkStatus { get; set; }
    }
}
