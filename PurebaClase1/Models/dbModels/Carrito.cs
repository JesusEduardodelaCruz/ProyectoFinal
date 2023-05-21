using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PurebaClase1.Models.dbModels
{
    [Table("Carrito")]
    public partial class Carrito
    {
        [Key]
        public int IdUsuario { get; set; }
        [Key]
        public int IdRopa { get; set; }
        [StringLength(10)]
        public string? Cantidad { get; set; }

        [ForeignKey("IdRopa")]
        [InverseProperty("Carritos")]
        public virtual Ropa IdRopaNavigation { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("Carritos")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
    }

