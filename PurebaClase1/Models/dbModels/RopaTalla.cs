using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PurebaClase1.Models.dbModels
{
    [Table("RopaTalla")]
    public partial class RopaTalla
    {
        [Key]
        public int IdRopa { get; set; }
        [Key]
        public int IdTalla { get; set; }
        [StringLength(10)]
        public string? Cantidad { get; set; }

        [ForeignKey("IdRopa")]
        [InverseProperty("RopaTallas")]
        public virtual Ropa IdRopaNavigation { get; set; } = null!;
        [ForeignKey("IdTalla")]
        [InverseProperty("RopaTallas")]
        public virtual Talla IdTallaNavigation { get; set; } = null!;
    }
}
