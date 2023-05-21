using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PurebaClase1.Models.dbModels
{
    [Table("MetodoDePago")]
    public partial class MetodoDePago
    {
        [Key]
        public int IdMetododepago { get; set; }
        public int IdUsuario { get; set; }
        public int NumeroDeTarjeta { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Titular { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        [Column("CVV")]
        public int Cvv { get; set; }

        [ForeignKey("IdUsuario")]
        [InverseProperty("MetodoDePagos")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
