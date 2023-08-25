namespace LogisticaAPI.Models
{
    public class EnvioTerrestre
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public int TipoProductoID { get; set; }
        public int BodegaID { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal PrecioEnvio { get; set; }
        public string PlacaVehiculo { get; set; }
        public string NumeroGuia { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public int CantidadProducto { get; set; }

        public Cliente Cliente { get; set; }
        public TipoDeProducto TipoProducto { get; set; }
        public Bodega Bodega { get; set; }
    }
}
