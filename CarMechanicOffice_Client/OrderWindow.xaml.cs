using CarMechanic_Common.DataProviders;
using CarMechanic_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarMechanicOffice_Client
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private readonly CustomerOrder _order;

        public OrderWindow(CustomerOrder order)
        {
            InitializeComponent();

            if (order != null)
            {
                _order = order;

                FirstNameTextBox.Text = _order.FirstName;
                LastNameTextBox.Text = _order.LastName;
                ModelTextBox.Text = _order.CarModel;
                PlateNumberModelTextBox.Text = _order.CarLicencePlateNumber;
                DescriptionModelTextBox.Text = _order.CarProblemDescription;

                CreateButton.Visibility = Visibility.Collapsed;

            }
            else
            {
                _order = new CustomerOrder();

                CreateButton.Visibility = Visibility.Visible;
                UpdateButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
                editableCheckBox.Visibility = Visibility.Collapsed;
                editableCheckBox.IsChecked = true;
            }

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCustomerOrder())
            {
                _order.FirstName = FirstNameTextBox.Text;
                _order.LastName = LastNameTextBox.Text;
                _order.CarModel = ModelTextBox.Text;
                _order.CarLicencePlateNumber = PlateNumberModelTextBox.Text;
                _order.CarProblemDescription = DescriptionModelTextBox.Text;
                _order.WorkStatus = CarWorkStatus.Recorded;
                _order.DateTime = DateTime.Now;

                CustomerOrderDataProvider.CreateCustomerOrder(_order);

                DialogResult = true;
                Close();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCustomerOrder())
            {
                _order.FirstName = FirstNameTextBox.Text;
                _order.LastName = LastNameTextBox.Text;
                _order.CarModel = ModelTextBox.Text;
                _order.CarLicencePlateNumber = PlateNumberModelTextBox.Text;
                _order.CarProblemDescription = DescriptionModelTextBox.Text;

                CustomerOrderDataProvider.UpdateCustomerOrder(_order);

                DialogResult = true;
                Close();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CustomerOrderDataProvider.DeleteCustomerOrder(_order.Id);

                DialogResult = true;
                Close();
            }
        }

        private bool ValidateCustomerOrder()
        {
            if (string.IsNullOrEmpty(FirstNameTextBox.Text))
            {
                MessageBox.Show("First name should not be empty.");
                return false;
            }

            if (!Regex.IsMatch(FirstNameTextBox.Text, @"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<spaces> (?=[A-Za-z]))){1,29}$"))
            {
                MessageBox.Show("First name must contain only letters.");
                return false;
            }

            if (string.IsNullOrEmpty(LastNameTextBox.Text))
            {
                MessageBox.Show("Last name should not be empty.");
                return false;
            }

            if (!Regex.IsMatch(LastNameTextBox.Text, @"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<spaces> (?=[A-Za-z]))){1,29}$"))
            {
                MessageBox.Show("Last name must contain only letters.");
                return false;
            }

            if (string.IsNullOrEmpty(ModelTextBox.Text))
            {
                MessageBox.Show("Car model should not be empty.");
                return false;
            }

            if (!Regex.IsMatch(ModelTextBox.Text, @"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z0-9])|(?<spaces> (?=[A-Za-z0-9]))){1,49}$"))
            {
                MessageBox.Show("Model name must contain only letters and numbers.");
                return false;
            }

            if (string.IsNullOrEmpty(PlateNumberModelTextBox.Text))
            {
                MessageBox.Show("Licence plate number should not be empty.");
                return false;
            }

            if (!Regex.IsMatch(PlateNumberModelTextBox.Text, @"^[A-Z]{1,3}-[0-9]{1,3}$"))
            {
                MessageBox.Show("Licence plate number must follow the given pattern: (XXX-000)");
                return false;
            }

            if (string.IsNullOrEmpty(DescriptionModelTextBox.Text))
            {
                MessageBox.Show("Problem description should not be empty.");
                return false;
            }

            if (!Regex.IsMatch(DescriptionModelTextBox.Text, @"^(?<firstchar>(?=[A-Za-z0-9]))((?<alphachars>[A-Za-z0-9])|(?<specialchars>[A-Za-z0-9]['-,](?=[A-Za-z0-9]))|(?<spaces> (?=[A-Za-z0-9]))|(?<marks>([.!?,]))){10,255}$"))
            {
                MessageBox.Show("Problem Description can contain only letters and numbers. Minimum 10 and maximum 255 characters.");
                return false;
            }

            return true;
        }
    }
}
