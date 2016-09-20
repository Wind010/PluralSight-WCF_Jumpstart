
using System.Runtime.Serialization;


namespace Zza.Entities
{
    [DataContract]
    public class OrderItem
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string OrderId { get; set; }

        [DataMember]
        public string ProductId { get; set; }

        [DataMember]
        public string Quantity { get; set; }

        [DataMember]
        public string UnitPrice { get; set; }

        [DataMember]
        public string TotalPrice { get; set; }


    }

}
