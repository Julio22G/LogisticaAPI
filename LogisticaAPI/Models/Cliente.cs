using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticaAPI.Models
{
    public class Cliente
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string NoDocumento { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }

        public int PaisID { get; set; }
       // public Pais Pais { get; set; }
    }
}
