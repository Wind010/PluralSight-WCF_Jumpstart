
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Zza.Entities
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Guid CustomerId { get; set; }

        [DataMember]
        public int OrderStatusId { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public List<OrderItem> OrderItems { get; set; }

    }

}
