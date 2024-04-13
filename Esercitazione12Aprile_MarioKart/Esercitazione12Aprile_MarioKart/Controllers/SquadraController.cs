using Esercitazione12Aprile_MarioKart.DTO;
using Esercitazione12Aprile_MarioKart.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Esercitazione12Aprile_MarioKart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SquadraController : Controller
    {

        private readonly SquadraService service;

        public SquadraController (SquadraService ser)
        {
            this.service = ser;
        }

        [HttpGet]
        public ActionResult StampaTutti()
        {
            return Ok(service.RecuperaTutti());
        }

        [HttpPost]
        public ActionResult InserisciSquadra(SquadraDTO dto)
        {
            return Ok(service.InserisciSquadra(dto));
        }

        [HttpDelete("{codice}")]
        public ActionResult EliminaSquadra(string codice)
        {
            return Ok(service.EliminaSquadra(codice));
        }

        [HttpGet("{codice}")]
        public ActionResult RecuperaPerCodice(string codice)
        {
            return Ok(service.RecuperaPerCodice(codice));
        }

        [HttpPut]
        public ActionResult ModificaSquadra(SquadraDTO dto)
        {
            return Ok(service.ModificaSquadra(dto));
        }

        [HttpGet("personaggi")]
        public ActionResult VisualizzaPersonaggiInSquadra(string codiceS)
        {
            return Ok(service.GetPersonaggiInSquadra(codiceS));
        }
    }
}
