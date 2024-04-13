using Esercitazione12Aprile_MarioKart.DTO;
using Esercitazione12Aprile_MarioKart.Model;
using Esercitazione12Aprile_MarioKart.Repository;

namespace Esercitazione12Aprile_MarioKart.Service
{
    public class PersonaggioService
    {
        private readonly PersonaggioRepository repo;
        public PersonaggioService(PersonaggioRepository repos)
        {
            repo = repos;
        }

        public bool InserisciPersonaggio(PersonaggioDTO dto)
        {
            if (repo.GetAll().Count() < 3)
            {
                Personaggio s = new Personaggio()
                {
                    CodicePersonaggio = Guid.NewGuid().ToString(),
                    NomePersonaggio = dto.NomPer,
                    CostoPersonaggio = dto.CosPer,
                    CategoriaPersonaggio = dto.CatPer,
                    FotoPersonaggio = dto.FotPer
                };

                return repo.Create(s);
            }
            else
                return false;
        }

        public bool ModificaPersonaggio(PersonaggioDTO dto)
        {
            if (dto.CodPer is not null)
            {
                Personaggio p = new Personaggio()
                {
                    CodicePersonaggio = dto.CodPer,
                    NomePersonaggio = dto.NomPer,
                    CostoPersonaggio = dto.CosPer,
                    CategoriaPersonaggio = dto.CatPer,
                    FotoPersonaggio = dto.FotPer
                };

                return repo.Update(p);
            }
            else
                return false;
        }

        public bool EliminaPersonaggio(string codice)
        {
            return repo.Delete(codice);
        }

        public List<PersonaggioDTO> RecuperaTutti()
        {
            return repo.GetAll().Select(p => new PersonaggioDTO()
            {
                CodPer=p.CodicePersonaggio,
                NomPer=p.NomePersonaggio,
                CosPer=p.CostoPersonaggio,
                CatPer=p.CategoriaPersonaggio,
                FotPer=p.FotoPersonaggio
            }).ToList();
        }

        public PersonaggioDTO RecuperaPerCodice(string codice)
        {
            Personaggio p = repo.GetByCodice(codice);

            PersonaggioDTO dto = new PersonaggioDTO()
            {
                CodPer = p.CodicePersonaggio,
                NomPer = p.NomePersonaggio,
                CosPer = p.CostoPersonaggio,
                CatPer = p.CategoriaPersonaggio,
                FotPer = p.FotoPersonaggio
            };

            return dto;
        }

        public bool InserisciPersonaggioInSquadra(string codS, string codP)
        {
            Personaggio p = repo.GetByCodice(codP);

            foreach(Personaggio per in repo.GetPersonaggiInSquadra(codS))
            {
                if (per.CategoriaPersonaggio == p.CategoriaPersonaggio && repo.GetPersonaggiInSquadra(codS).Count() >=3)
                {
                    return false;
                }
            }

            return repo.InserisciPersonaggioInSquadra(codS, codP);
        }
    }
}
