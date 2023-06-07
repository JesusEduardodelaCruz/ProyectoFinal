namespace PurebaClase1.Models
{
    public class DireccionesHR
    {
        public int IdDireccion { get; set; }
        public int IdUsuario { get; set; }
        public string Colonia { get; set; } = null!;        
        public string Calle { get; set; } = null!;
        public int NoExt { get; set; }
        public int CodigoPostal { get; set; }
    }
}
