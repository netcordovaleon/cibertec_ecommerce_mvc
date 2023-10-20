using SolECommerce.DataAccess.DBEntities.Abstraccions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolECommerce.DataAccess.DBEntities
{
    [Table("OrderDetail")]
    public class OrderDetailEntity : EntityBase
    {
        public double FinalPrice { get; set; }
        public virtual ProductEntity Product { get; set; }
        public virtual OrderEntity Order { get; set; }
    }
}
