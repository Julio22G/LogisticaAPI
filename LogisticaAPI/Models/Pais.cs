using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LogisticaAPI.Models
{
    public class Pais
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string CodigoIso2 { get; set; } // Código ISO de 2 letras del país

        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
        public ICollection<Puerto> Puertos { get; set; } = new List<Puerto>();
    }

}
