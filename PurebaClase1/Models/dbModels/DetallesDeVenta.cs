using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PurebaClase1.Models.dbModels
{
    public partial class DetallesDeVenta
    {
        [Key]
        public int IdVentas { get; set; }
        [Key]
        public int IdRopa { get; set; }
        [Column(TypeName = "money")]
        public decimal Precio { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Cantidad { get; set; }

        [ForeignKey("IdRopa")]
        [InverseProperty("DetallesDeVenta")]
        public virtual Ropa IdRopaNavigation { get; set; } = null!;
        [ForeignKey("IdVentas")]
        [InverseProperty("DetallesDeVenta")]
        public virtual Venta IdVentasNavigation { get; set; } = null!;
    }
}
