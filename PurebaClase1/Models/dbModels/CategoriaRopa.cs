using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PurebaClase1.Models.dbModels
{
    [Table("CategoriaRopa")]
    public partial class CategoriaRopa
    {
        public CategoriaRopa()
        {
            Ropas = new HashSet<Ropa>();
        }

        [Key]
        public int IdCategoria { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;

        [InverseProperty("IdCategoriaNavigation")]
        public virtual ICollection<Ropa> Ropas { get; set; }
    }
}
