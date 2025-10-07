using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoEstacionamento.Models
{
    internal class Veiculo
    {

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int Placa { get; set; }
        public int Modelo { get; set; }
        public int Cor { get; set; }

    }
}    
