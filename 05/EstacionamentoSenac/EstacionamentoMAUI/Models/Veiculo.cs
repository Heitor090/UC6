

using System.ComponentModel.DataAnnotations;

namespace EstacionamentoMAUI.Models
{
    public class Veiculo
    {
     
        public int Id { get; set; }

        
        public string Placa { get; set; }

        public string? Modelo { get; set; }

       
        public string? Cor { get; set; }

        [Required]
        public int MotoristaId { get; set; }
        public Motorista? Motorista { get; set; }
    }
}
