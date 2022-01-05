using CarMechanic_Common.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMechanic_Common.Models
{
    public class CustomerOrder : PropertyValidateModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [Required]
        [RegularExpression(@"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<spaces> (?=[A-Za-z]))){1,29}$",
            ErrorMessage = "Your First Name can contain only letters. Length cannot more than 30 characters")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<spaces> (?=[A-Za-z]))){1,29}$",
            ErrorMessage = "Your Last Name can contain only letters. Length cannot more than 30 characters")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z0-9])|(?<spaces> (?=[A-Za-z0-9]))){1,49}$",
            ErrorMessage = "Your Car Model can contain only letters and digits. Length cannot more than 50 characters")]
        public string CarModel { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{1,3}-[0-9]{1,3}$",
            ErrorMessage = "Licence plate number must follow the given pattern: (XXX-000)")]
        public string CarLicencePlateNumber { get; set; }

        [Required]
        [RegularExpression(@"^(?<firstchar>(?=[A-Za-z0-9]))((?<alphachars>[A-Za-z0-9])|(?<specialchars>[A-Za-z0-9]['-,](?=[A-Za-z0-9]))|(?<spaces> (?=[A-Za-z0-9]))|(?<marks>([.!?,]))){10,255}$",
            ErrorMessage = "Problem Description can contain only letters and numbers. Minimum 10 and maximum 255 characters.")]
        public string CarProblemDescription { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        public CarWorkStatus WorkStatus { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {CarModel} ({CarLicencePlateNumber}): {CarProblemDescription} - {WorkStatus}";
        }
    }
}
