namespace LogisticaAPI.Models
{
    public class EnvioMaritimo
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public int TipoProductoID { get; set; }
        public int PuertoID { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal PrecioEnvio { get; set; }
        public string NumeroFlota { get; set; }
        public string NumeroGuia { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public int CantidadProducto { get; set; }

        //public Cliente Cliente { get; set; }
        //public TipoDeProducto TipoProducto { get; set; }
        //public Puerto Puerto { get; set; }
    }
}
