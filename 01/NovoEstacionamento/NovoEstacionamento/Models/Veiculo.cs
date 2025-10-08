namespace NovoEstacionamento.Models
{
    internal class Veiculo
    {

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int Placa { get; set; }
        public int Modelo { get; set; }
        public int Cores { get; set; }

        public Cliente Cliente { get; set; }
    }
}    
