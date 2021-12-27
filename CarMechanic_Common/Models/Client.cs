using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(40)]
        public string CarModel { get; set; }
        [Required]
        [MaxLength(10)]
        public string CarLicencePlateNumber { get; set; }
        [Required]
        [MaxLength(255)]
        public string CarProblemDescription { get; set; }
        [Required]
        public CarWorkStatus WorkStatus { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {CarModel} ({CarLicencePlateNumber}): {CarProblemDescription}";
        }
    }
}
