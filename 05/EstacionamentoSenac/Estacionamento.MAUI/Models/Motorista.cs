using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estacionamento.MAUI.Models
{
    
    public class Motorista
    {
        public int Id { get; set; }           
        public string Nome { get; set; }               
        public string Cpf { get; set; }
        public string? Telefone { get; set; }
        public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
    }
}
