using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PurebaClase1.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            Carritos = new HashSet<Carrito>();
            Direccions = new HashSet<Direccion>();
            MetodoDePagos = new HashSet<MetodoDePago>();
            Tickets = new HashSet<Ticket>();
            Venta = new HashSet<Venta>();
        }

        public int Edad { get; set;  } 
        [Column(TypeName = "text")]
        public string? IdDireccion { get; set; } = null!;
        [Column(TypeName = "numeric(18, 0)")]
        public int? IdMetododePago { get; set; }

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Direccion> Direccions { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<MetodoDePago> MetodoDePagos { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Ticket> Tickets { get; set; }
        [InverseProperty("IdUsuariosNavigation")]
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
