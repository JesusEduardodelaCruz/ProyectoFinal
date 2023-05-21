using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PurebaClase1.Models.dbModels
{
    [Table("Ropa")]
    public partial class Ropa
    {
        public Ropa()
        {
            Carritos = new HashSet<Carrito>();
            DetallesDeVenta = new HashSet<DetallesDeVenta>();
            RopaTallas = new HashSet<RopaTalla>();
        }

        [Key]
        public int IdRopa { get; set; }
        
        public int IdColor { get; set; }
        public int IdCategoria { get; set; }
        [Column(TypeName = "image")]
        public string? Imagen { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Titulo { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;

        [ForeignKey("IdCategoria")]
        [InverseProperty("Ropas")]
        public virtual CategoriaRopa IdCategoriaNavigation { get; set; } = null!;
        [ForeignKey("IdColor")]
        [InverseProperty("Ropas")]
        public virtual Color IdColorNavigation { get; set; } = null!;
        [InverseProperty("IdRopaNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdRopaNavigation")]
        public virtual ICollection<DetallesDeVenta> DetallesDeVenta { get; set; }
        [InverseProperty("IdRopaNavigation")]
        public virtual ICollection<RopaTalla> RopaTallas { get; set; }
    }
}
