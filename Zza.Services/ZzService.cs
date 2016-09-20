
using System;

using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;


namespace Zza.Services
{
    using Entities;
    using Data;

    // PerCall will create a new objects per request and dispose them when complete.

    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class ZzService : IZzService, IDisposable
    {
        readonly ZzaDbContext _context = new ZzaDbContext();

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        // This specifies that the method will be done atomically via transaction.
        [OperationBehavior(TransactionScopeRequired=true)]
        public void SubmitOrdre(Order order)
        {
            _context.Orders.Add(order);
            order.OrderItems.ForEach(oi => _context.OrderItems.Add(oi));
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
