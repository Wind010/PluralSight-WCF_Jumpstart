
using System.Collections.ObjectModel;

namespace Zza.Client
{
    using Entities;
    using System;
    using System.Diagnostics;
    using ZzaServices;

    public class Program
    {
        private static ZzServiceClient _proxy;

        private static ObservableCollection<Product> _products;
        private static ObservableCollection<Customer> _customers;

        static void Main(string[] args)
        {
            try
            {
                // _proxy = new ZzaProxy("BasicHttpBinding_IZzService");
                _proxy = new ZzServiceClient("BasicHttpBinding_IZzService");

                // If needed, this is how you can set the client credentials.
                //_proxy.ClientCredentials.Windows.ClientCredential.UserName = "AD\\Test";
                //_proxy.ClientCredentials.Windows.ClientCredential.Password = "Password";

                LoadProductsAndCustomers();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
        private async static void LoadProductsAndCustomers()
        {
            try
            {
                _products = await _proxy.GetProductsAsync();
                _customers = await _proxy.GetCustomersAsync();
            }
            finally
            {
                _proxy.Close();
            }
        }

        private void OnSubmitOrder()
        {
            try
            {
                // Set order;
                var order = new Order();

                order.CustomerId = Guid.NewGuid();

                order.OrderDate = DateTime.Now;
                order.OrderStatusId = 1;
                _proxy.SubmitOrder(order);

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error saving order, please try again later");
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                _proxy.Close();
            }
        }


    }
}
