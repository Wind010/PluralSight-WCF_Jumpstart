
using System;

using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using System.Threading;
using System.Security.Permissions;
using System.Security;
using System.Security.Claims;

namespace Zza.Services
{
    using Entities;
    using Data;



    // PerCall will create a new objects per request and dispose them when complete.

    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class ZzaService : IZzService, IDisposable
    {
        readonly ZzaDbContext _context = new ZzaDbContext();

        // Option 2:
        [PrincipalPermission(SecurityAction.Demand, Role = "BUILTIN\\Administrators")]
        public List<Customer> GetCustomers()
        {
            // This will be the accessing client principal.
            var principal = Thread.CurrentPrincipal;

            // Check roles option 1:
            //if (!principal.IsInRole("BUILTIN\\Administrators"))
            //{
            //    throw new SecurityException("Access Denied");
            //}

            // Option 3 - Use ClaimsPrincipals:
            //ClaimsPrincipal.Current.HasClaim()

            return _context.Customers.ToList();
        }
        

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        // This specifies that the method will be done atomically via transaction.
        [OperationBehavior(TransactionScopeRequired=true)]
        public void SubmitOrder(Order order)
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
