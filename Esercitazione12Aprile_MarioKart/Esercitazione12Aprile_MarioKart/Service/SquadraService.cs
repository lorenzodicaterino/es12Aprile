using Esercitazione12Aprile_MarioKart.DTO;
using Esercitazione12Aprile_MarioKart.Model;
using Esercitazione12Aprile_MarioKart.Repository;

namespace Esercitazione12Aprile_MarioKart.Service
{
    public class SquadraService
    {
        private readonly SquadraRepository repo;

        public SquadraService(SquadraRepository repos)
        {
            this.repo = repos;
        }

        public bool InserisciSquadra(SquadraDTO dto)
        {
            if (repo.GetAll().Count() < 3)
            {
                Squadra s = new Squadra()
                {
                    CodiceSquadra = Guid.NewGuid().ToString().ToUpper(),
                    NomeSquadra = dto.NomSqu,
                    Crediti = 10
                };

                return repo.Create(s);
            }
            else
                return false;
        }

        public bool ModificaSquadra(SquadraDTO dto)
        {
            if (dto.CodSqu is not null)
            {
                Squadra s = new Squadra()
                {
                    CodiceSquadra = dto.CodSqu,
                    NomeSquadra = dto.NomSqu is not null ? dto.NomSqu : null,
                    Crediti = dto.CreSqu > 0 ? dto.CreSqu : 0,
                };

                return repo.Update(s);
            }
            else
                return false;
        }

        public bool EliminaSquadra(string codice)
        {
            return repo.Delete(codice);
        }

        public List<SquadraDTO> RecuperaTutti()
        {
            return repo.GetAll().Select(p => new SquadraDTO()
            {
                CodSqu = p.CodiceSquadra,
                NomSqu = p.NomeSquadra,
                CreSqu = p.Crediti
            }).ToList();
        }

        public SquadraDTO RecuperaPerCodice(string codice)
        {
            Squadra p = repo.GetByCodice(codice);

            SquadraDTO dto = new SquadraDTO()
            {
                CodSqu = p.CodiceSquadra,
                NomSqu = p.NomeSquadra,
                CreSqu = p.Crediti
            };

            return dto;
        }

        public List<PersonaggioDTO> GetPersonaggiInSquadra(string codice)
        {
            return repo.GetPersonaggiInSquadra(codice).Select(p => new PersonaggioDTO()
            {
                CodPer = p.CodicePersonaggio,
                NomPer = p.NomePersonaggio,
                CosPer = p.CostoPersonaggio,
                CatPer = p.CategoriaPersonaggio,
                FotPer = p.FotoPersonaggio
            }).ToList();
        }
    }
}
