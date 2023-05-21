using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PurebaClase1.Models.dbModels
{
    [Table("Direccion")]
    public partial class Direccion
    {
        [Key]
        public int IdDireccion { get; set; }
        public int IdUsuario { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Colonia { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Calle { get; set; } = null!;
        [Column("No_Ext")]
        public int NoExt { get; set; }
        public int CodigoPostal { get; set; }

        [ForeignKey("IdUsuario")]
        [InverseProperty("Direccions")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
