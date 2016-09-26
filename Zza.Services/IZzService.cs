using System.Collections.Generic;
using System.ServiceModel;

namespace Zza.Services
{
    using Entities;

    [ServiceContract]
    public interface IZzService
    {
        [OperationContract]
        List<Product> GetProducts();

        [OperationContract]
        List<Customer> GetCustomers();

        [OperationContract]
        void SubmitOrder(Order order);

    }


}
