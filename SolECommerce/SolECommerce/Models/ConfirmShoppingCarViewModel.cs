using System.Collections.Generic;

namespace SolECommerce.Models
{
    public class ConfirmShoppingCarViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string User { get; set; }
        public string Password { get; set; }


        public string CredictCartNumber { get; set; }
        public string ExpiredCartDate { get; set; }
        public string CVV { get; set; }
        public string Email { get; set; }


        public List<ProductTemporalViewModel> TemporalProducts { get; set; }
        public ConfirmShoppingCarViewModel()
        {
            TemporalProducts = new List<ProductTemporalViewModel>();
        }

    }
}
