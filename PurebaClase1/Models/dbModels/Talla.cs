using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PurebaClase1.Models.dbModels
{
    [Table("Talla")]
    public partial class Talla
    {
        public Talla()
        {
            RopaTallas = new HashSet<RopaTalla>();
        }

        [Key]
        public int IdTalla { get; set; }
        [StringLength(10)]
        public string? Descripcion { get; set; }

        [InverseProperty("IdTallaNavigation")]
        public virtual ICollection<RopaTalla> RopaTallas { get; set; }
    }
}
