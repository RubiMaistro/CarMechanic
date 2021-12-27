using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMechanic_Common.Models
{
    public enum CarWorkStatus
    { 
        Recorded,
        InProgress,
        Finished
    }
    public class Client
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarModel { get; set; }
        public string CarLicencePlateNumber { get; set; }
        public string CarProblemDescription { get; set; }
        public CarWorkStatus WorkStatus { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {CarModel} ({CarLicencePlateNumber}): {CarProblemDescription}";
        }
    }
}
