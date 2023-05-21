using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PurebaClase1.Models.dbModels
{
    [Table("CategoriaTicket")]
    public partial class CategoriaTicket
    {
        public CategoriaTicket()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int IdCategoria { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;

        [InverseProperty("IdCategoriaNavigation")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
