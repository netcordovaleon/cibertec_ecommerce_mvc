using SolECommerce.DataAccess.DBEntities.Abstraccions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolECommerce.DataAccess.DBEntities
{
    [Table("Client")]
    public class ClientEntity : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
