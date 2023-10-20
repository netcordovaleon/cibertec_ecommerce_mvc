using SolECommerce.DataAccess.DBEntities.Abstraccions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace SolECommerce.DataAccess.DBEntities
{
    [Table("Product")]
    public class ProductEntity : EntityBase
    {
        public string SKU { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public double? OriginalPrice { get; set; }
        public double? Discount { get; set; }
        public double? FinalPrice { get; set; }
        public int Stock { get; set; }
        public bool? FreeShipping { get; set; } //Envio Gratis
        public bool? HomeDelivery { get; set; } //Envio Domicilio
        public bool? PickupInStore { get; set; } //Retiro en tienda
        public string ImageURL { get; set; }
        public string Description { get; set; }

    }
}
