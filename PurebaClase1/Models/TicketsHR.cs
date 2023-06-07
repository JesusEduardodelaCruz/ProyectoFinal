using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PurebaClase1.Models
{
    public class TicketsHR
    {
        public int IdTicket { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? IdUsuario { get; set; }
        public int? IdCategoria { get; set; }

    }
}
