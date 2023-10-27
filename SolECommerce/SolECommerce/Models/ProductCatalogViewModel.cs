namespace SolECommerce.Models
{
    public class ProductCatalogViewModel
    {
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public double? OriginalPrice { get; set; }
        public double? Discount { get; set; }
        public double? FinalPrice { get; set; }
        public int Stock { get; set; }
        public bool? FreeShipping { get; set; } 
        public bool? HomeDelivery { get; set; }  
        public bool? PickupInStore { get; set; }  
        public string ImageURL { get; set; }
        public string Description { get; set; }
    }
}
