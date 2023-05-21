using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PurebaClase1.Models.dbModels
{
    [Table("Color")]
    public partial class Color
    {
        public Color()
        {
            Ropas = new HashSet<Ropa>();
        }

        [Key]
        public int IdColor { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? Descripcion { get; set; }

        [InverseProperty("IdColorNavigation")]
        public virtual ICollection<Ropa> Ropas { get; set; }
    }
}
