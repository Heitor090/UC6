using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.MAUI.Models
{
    public class Vaga    {
       
        public int Id { get; set; }        
        public string Localizacao { get; set; }       
        public string? TipoVaga { get; set; }
    }
}
