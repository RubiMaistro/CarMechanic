using CarMechanic_Common.Models;
using CarMechanic_Common.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CarMechanic_Common.Tests
{
    [TestClass]
    public class CustomerOrderUnitTests
    {

        [DataRow("Test FirstName", "Test LastName", "Test Model", "AAA-111", "Test Problem")]
        [DataRow("Elon", "Musk", "Tesla Model S", "TSL-005", "Tire replacement required")]
        [TestMethod]
        public void validateFirstName_WithValidArguments_ValidCustomerOrder
            (string firstName, string lastName, string carModel, string plateNumber, string problem)
        {
            // Arrange
            var validator = new ValidationModelHelper();
            var order = CreateCustomerOrder(firstName, lastName, carModel, plateNumber, problem);

            // Act
            var results = validator.Validate(order);

            // Assert
            Assert.AreEqual(results.Count, 0);
            Assert.IsNotNull(order);
        }

        [DataRow(null, "Test LastName", "Test Model", "AAA-111", "Test Problem")]
        [TestMethod]
        public void validateFirstName_WithNullArgument_ExpectOneValidationError
            (string firstName, string lastName, string carModel, string plateNumber, string problem)
        {
            // Arrange
            var validator = new ValidationModelHelper();
            var order = CreateCustomerOrder(firstName, lastName, carModel, plateNumber, problem);

            // Act
            var results = validator.Validate(order);

            // Assert
            Assert.IsNull(order.FirstName, results[0].ErrorMessage);
            Assert.AreEqual(results.Count, 1, results[0].ErrorMessage);
            Assert.AreEqual("The FirstName field is required.", results[0].ErrorMessage);
        }

        [DataRow("FirstName", "LastName", "Model", "AAA-111", "Test Problem")]
        [TestMethod]
        public void validateCarProblemDescription_Exceeds_255_Characters_ExpectError
            (string firstName, string lastName, string carModel, string plateNumber, string problem)
        {
            // Arrange
            var validator = new ValidationModelHelper();
            var order = CreateCustomerOrder(firstName, lastName, carModel, plateNumber, new string('c',256));

            // Act
            var results = validator.Validate(order);

            // Assert
            Assert.AreEqual(results.Count, 1, results[0].ErrorMessage);
            Assert.AreEqual(results[0].ErrorMessage, 
                "Problem Description can contain only letters and numbers. Minimum 10 and maximum 255 characters.");
        }

        [DataRow("12345", "Last", "Model", "AAA-111", "Problem")]
        [DataRow("First", "1234", "Model", "AAA-111", "Problem")]
        [DataRow("First", "Last", "?$#_'", "AAA-111", "Problem")]
        [DataRow("First", "Last", "Model", "000-111", "Problem")]
        [DataRow("First", "Last", "Model", "222-AAA", "Problem")]
        [DataRow("First", "Last", "Model", "abc-333", "Problem")]
        [DataRow("12345", "1234", "!!!!!", "abc-4de", "What is the problem?! $$#%")]
        [TestMethod]
        public void validateCustomerOrder_WithInvalidArguments_InvalidCustomerOrder
            (string firstName, string lastName, string carModel, string plateNumber, string problem)
        {
            // Arrange
            var CheckValidation = new ValidationModelHelper();
            var order = CreateCustomerOrder(firstName, lastName, carModel, plateNumber, problem);

            // Act
            var results = CheckValidation.Validate(order);

            // Assert
            Assert.IsTrue(results.Count > 0, results[0].ErrorMessage);
        }

        private CustomerOrder CreateCustomerOrder
            (string firstName, string lastName, string carModel, string plateNumber, string problem)
        {
            return new CustomerOrder
            {
                FirstName = firstName,
                LastName = lastName,
                CarModel = carModel,
                CarLicencePlateNumber = plateNumber,
                CarProblemDescription = problem
            };
        }
    }
}
