using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolECommerce.DataAccess.DBEntities.Abstraccions
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        //[Column("NombreColumna")]
        public bool Status { get; set; }
    }
}
