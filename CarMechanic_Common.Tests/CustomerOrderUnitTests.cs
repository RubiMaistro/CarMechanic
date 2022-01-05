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
        public void validateCustomerOrder_WithValidArgument_ValidCustomerOrder
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
        public void validateCustomerOrder_FirstNameIsNull_ExpectOneValidationError
            (string firstName, string lastName, string carModel, string plateNumber, string problem)
        {
            // Arrange
            var validator = new ValidationModelHelper();
            var order = CreateCustomerOrder(firstName, lastName, carModel, plateNumber, problem);

            // Act
            var results = validator.Validate(order);

            // Assert
            Assert.IsNull(order.FirstName);
            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual("The FirstName field is required.", results[0].ErrorMessage);
        }

        [DataRow("12345", "Last", "Model", "AAA-111", "Problem")]
        [DataRow("First", "1234", "Model", "AAA-111", "Problem")]
        [DataRow("First", "Last", "?$'", "AAA-111", "Problem")]
        [DataRow("First", "Last", "Model", "000-111", "Problem")]
        [DataRow("First", "Last", "Model", "222-AAA", "Problem")]
        [DataRow("First", "Last", "Model", "abc-333", "Problem")]
        [DataRow("First", "Last", "Model", "AAA-333", "What is the problem?!")]
        [DataRow("12345", "1234", "!!!!!", "abc-4de", "What is the problem?! $$$%")]
        //[TestMethod]
        public void validateCustomerOrder_WithInvalidArgument_InvalidCustomerOrder
            (string firstName, string lastName, string carModel, string plateNumber, string problem)
        {
            // Arrange
            var CheckValidation = new ValidationModelHelper();
            var order = CreateCustomerOrder(firstName, lastName, carModel, plateNumber, problem);

            // Act
            var results = CheckValidation.Validate(order);

            // Assert
            Assert.IsTrue(results.Count > 0);
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
