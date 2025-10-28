using EstacionamentoSenac.API.Data;
using EstacionamentoSenac.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoSenac.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoristasController : ControllerBase
    {
        private AppDbContext _context;

        public MotoristasController(AppDbContext context)
        {
            _context = context;
        }

        public string Teste() => "Teste MOtoristaController";

        [HttpGet]

        public ActionResult<Motorista> GetMotoristas()
        {
            return Ok(_context.Motoristas.ToList());
        }

        [HttpGet("{ id }")]

        public ActionResult<Motorista> GetMotoristaByID(int id)
        {
            var motorista = _context.Motoristas.Find(id);
            if (id == null)
                return NotFound();

            return Ok(motorista);
        }

        [HttpPost]

        public ActionResult<Motorista> PostMotorista(Motorista motorista)
        {
            _context.Motoristas.Add(motorista);
            _context.SaveChanges();

            return Created();

        }

        [HttpPut("{id}")]

        public ActionResult<Motorista> PutMotorista(int id, Motorista motoristaNovo)
        {
            if (id != motoristaNovo.Id)
                return BadRequest("Motorista informado na URL é diferente do arquivo Json");

            var motoristaExistente = _context.Motoristas.Find(id);
            if (motoristaExistente == null)
                return NotFound();

            motoristaExistente.Nome = motoristaNovo.Nome;

            _context.SaveChanges();
            return NoContent();
        }



        [HttpDelete]


     public ActionResult<Motorista> DeleteMotorista(int id)
        {
            var motorista = _context.Motoristas.Find(id);
            if (motorista == null) return NotFound();

            _context.Motoristas.Remove(motorista);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
