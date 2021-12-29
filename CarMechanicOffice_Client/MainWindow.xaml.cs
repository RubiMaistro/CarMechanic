using CarMechanic_Common.Models;
using CarMechanicOffice_Client.DataProviders;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarMechanicOffice_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UpdatedDescOrdersListBox();
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var selectedOrder = OrdersDataGrid.SelectedItem as CustomerOrder;

            if (selectedOrder != null)
            {
                var window = new OrderWindow(selectedOrder);
                if (window.ShowDialog() ?? false)
                {
                    UpdatedDescOrdersListBox();
                }

                OrdersDataGrid.UnselectAll();
            }

        }

        private void AddOrder_Click(object sender, RoutedEventArgs args)
        {
            var window = new OrderWindow(null);
            if (window.ShowDialog() ?? false)
            {
                UpdatedDescOrdersListBox();
            }
        }

        private void ASC_Click(object sender, RoutedEventArgs args)
        {
            UpdatedAscOrdersListBox();
        }

        private void DESC_Click(object sender, RoutedEventArgs args)
        {
            UpdatedDescOrdersListBox();
        }

        private void UpdatedDescOrdersListBox()
        {
            var orders = CustomerOrderDataProvider.GetCustomerOrders().ToArray().Reverse();
            OrdersDataGrid.ItemsSource = orders;
        }

        private void UpdatedAscOrdersListBox()
        {
            var orders = CustomerOrderDataProvider.GetCustomerOrders().ToArray();
            OrdersDataGrid.ItemsSource = orders;
        }
    }
}
