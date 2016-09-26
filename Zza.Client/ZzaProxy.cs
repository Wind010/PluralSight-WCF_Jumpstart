
using System.Collections.Generic;
using System.ServiceModel;

using System.ServiceModel.Channels;

namespace Zza.Client
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Entities;
    using ZzaServices;

    class ZzaProxy : ClientBase<IZzService>, IZzService
    {
        public ZzaProxy() { }

        public ZzaProxy(string endpointName) : base(endpointName) { }

        public ZzaProxy(Binding binding, string address) : base(binding, new EndpointAddress(address)) { }



        public Task<ObservableCollection<Customer>> GetCustomersAsync()
        {
            return Channel.GetCustomersAsync();
        }


        public Task<ObservableCollection<Product>> GetProductsAsync()
        {
            return Channel.GetProductsAsync();
        }

        public void SubmitOrder(Order order)
        {
            Channel.SubmitOrder(order);
        }

        public Task SubmitOrderAsync(Order order)
        {
            return Channel.GetCustomersAsync();
        }

        ObservableCollection<Customer> IZzService.GetCustomers()
        {
            return Channel.GetCustomers();
        }

        ObservableCollection<Product> IZzService.GetProducts()
        {
            return Channel.GetProducts();
        }

    }
}
