using SolECommerce.DataAccess.DBEntities.Abstraccions;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolECommerce.DataAccess.DBEntities
{
    [Table("Order")]
    public class OrderEntity : EntityBase
    {
        public DateTime OrderDate { get; set; }
        public string CredictCartNumber { get; set; }
        public string ExpiredCartDate { get; set; }
        public string CVV { get; set; }
        public string Email { get; set; }
        public virtual ClientEntity Client { get; set; }
    }
}
