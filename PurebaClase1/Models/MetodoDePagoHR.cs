using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PurebaClase1.Models
{
    public class MetodoDePagoHR
    {
        public int IdMetododepago { get; set; }
        public int IdUsuario { get; set; }
        public int NumeroDeTarjeta { get; set; }
        public string Titular { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public int Cvv { get; set; }

    }
}
