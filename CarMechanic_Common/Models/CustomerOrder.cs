using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    public class CustomerOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Your First Name can contain only 30 characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Your Last Name can contain only 30 characters")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Your Car Model can contain only 40 characters")]
        public string CarModel { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Car Licence Plate Number can contain only 10 characters")]
        public string CarLicencePlateNumber { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Problem Description can contain only 255 characters")]
        public string CarProblemDescription { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [Required]
        public CarWorkStatus WorkStatus { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {CarModel} ({CarLicencePlateNumber}): {CarProblemDescription} - {WorkStatus}";
        }
    }
}
