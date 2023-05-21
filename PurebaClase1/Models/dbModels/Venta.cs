using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PurebaClase1.Models.dbModels
{
    public partial class Venta
    {
        public Venta()
        {
            DetallesDeVenta = new HashSet<DetallesDeVenta>();
        }

        [Key]
        public int IdVentas { get; set; }
        public int? IdUsuarios { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [ForeignKey("IdUsuarios")]
        [InverseProperty("Venta")]
        public virtual ApplicationUser IdUsuariosNavigation { get; set; }
        [InverseProperty("IdVentasNavigation")]
        public virtual ICollection<DetallesDeVenta> DetallesDeVenta { get; set; }
    }
}
