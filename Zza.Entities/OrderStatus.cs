


using System.Runtime.Serialization;

namespace Zza.Entities
{
    [DataContract]
    public class OrderStatus
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
