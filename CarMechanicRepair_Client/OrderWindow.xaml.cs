using System.Collections;
using CarMechanic_Common.DataProviders;
using CarMechanic_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarMechanicRepair_Client
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

            _order = order;

            FirstNameTextBox.Text = _order.FirstName;
            LastNameTextBox.Text = _order.LastName;
            ModelTextBox.Text = _order.CarModel;
            PlateNumberTextBox.Text = _order.CarLicencePlateNumber;
            DescriptionModelTextBox.Text = _order.CarProblemDescription;
            WorkStatusDropdown.SelectedItem = _order.WorkStatus;

            WorkStatusDropdown.ItemsSource = Enum.GetValues(typeof(CarWorkStatus)).Cast<CarWorkStatus>();

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            _order.WorkStatus = (CarWorkStatus)WorkStatusDropdown.SelectedItem;

            CustomerOrderDataProvider.UpdateCustomerOrder(_order);

            DialogResult = true;
            Close();
            
        }
    }
}
