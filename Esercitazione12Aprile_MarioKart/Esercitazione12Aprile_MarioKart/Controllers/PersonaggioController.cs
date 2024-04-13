using Esercitazione12Aprile_MarioKart.DTO;
using Esercitazione12Aprile_MarioKart.Service;
using Microsoft.AspNetCore.Mvc;

namespace Esercitazione12Aprile_MarioKart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaggioController : Controller
    {
        private readonly PersonaggioService service;
        public PersonaggioController(PersonaggioService ser)
        {
            this.service = ser;
        }

        [HttpGet]
        public ActionResult StampaTutti()
        {
            return Ok(service.RecuperaTutti());
        }

        [HttpPost]
        public ActionResult InserisciPersonaggio(PersonaggioDTO dto)
        {
            return Ok(service.InserisciPersonaggio(dto));
        }

        [HttpDelete("{codice}")]
        public ActionResult EliminaPersonaggio(string codice)
        {
            return Ok(service.EliminaPersonaggio(codice));
        }

        [HttpGet("{codice}")]
        public ActionResult RecuperaPerCodice(string codice)
        {
            return Ok(service.RecuperaPerCodice(codice));
        }

        [HttpPut]
        public ActionResult ModificaPersonaggio(PersonaggioDTO dto)
        {
            return Ok(service.ModificaPersonaggio(dto));
        }

        [HttpGet("personaggi-in-squadra")]
        public ActionResult InserisciPersonaggioInSquadra(string codS, string codP)
        {
            return Ok(service.InserisciPersonaggioInSquadra(codS, codP));
        }
    }
}
