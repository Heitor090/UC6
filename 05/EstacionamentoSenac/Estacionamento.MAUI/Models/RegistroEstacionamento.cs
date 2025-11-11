using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.MAUI.Models
{
    public class RegistroEstacionamento
    {
        
        public int Id { get; set; }       
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }        
        public int VagaId { get; set; }
        public Vaga Vaga { get; set; }      
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
        public decimal? ValorFinal { get; set; }
    }
}
