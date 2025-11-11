using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.MAUI.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string? Modelo { get; set; }
        public string? Cor { get; set; }
        public int MotoristaId { get; set; }
        public Motorista Motorista { get; set; }
    }
}
