using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PurebaClase1.Models
{
    public class RopaHR
    {
        public int IdRopa { get; set; }
        
        public int IdColor { get; set; }
        public int IdCategoria { get; set; }
        
        public string? Imagen { get; set; }
        
        public string Titulo { get; set; } = null!;
       
        public string Descripcion { get; set; } = null!;
    }
}
