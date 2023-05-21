using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PurebaClase1.Models.dbModels
{
    [Table("Ticket")]
    public partial class Ticket
    {
        [Key]
        public int IdTicket { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;
        public int? IdUsuario { get; set; }
        public int? IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        [InverseProperty("Tickets")]
        public virtual CategoriaTicket? IdCategoriaNavigation { get; set; }
        [ForeignKey("IdUsuario")]
        [InverseProperty("Tickets")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; }
    }
}
