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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarMechanicRepair_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UpdatedOrdersListBox();
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var selectedOrder = OrdersDataGrid.SelectedItem as CustomerOrder;

            if (selectedOrder != null)
            {
                var window = new OrderWindow(selectedOrder);
                if (window.ShowDialog() ?? false)
                {
                    UpdatedOrdersListBox();
                }

                OrdersDataGrid.UnselectAll();
            }

        }

        private void UpdatedOrdersListBox()
        {
            var orders = CustomerOrderDataProvider.GetCustomerOrders().ToArray().Reverse();
            OrdersDataGrid.ItemsSource = orders;
        }
    }
}
