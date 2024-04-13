using Esercitazione12Aprile_MarioKart.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Linq;

namespace Esercitazione12Aprile_MarioKart.Repository
{
    public class PersonaggioRepository : IRepository<Personaggio>
    {
        private readonly Es12AprileContext ctx;

        public PersonaggioRepository(Es12AprileContext context)
        {
            ctx = context;
        }

        public IEnumerable<Personaggio> GetAll()
        {
            return ctx.Personaggios.ToList();
        }

        public bool Create(Personaggio entity)
        {
            try
            {
                ctx.Personaggios.Add(entity);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return false;
        }

        public Personaggio? Get(int id)
        {
            return ctx.Personaggios.FirstOrDefault(p => p.PersonaggioId == id);
        }

        public bool Delete(string codice)
        {
            try
            {
                ctx.Personaggios.Remove(ctx.Personaggios.FirstOrDefault(p => p.CodicePersonaggio == codice));
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public bool Update(Personaggio entity)
        {
            Personaggio temp = this.GetByCodice(entity.CodicePersonaggio);

            if (temp is not null)
            {
                try
                {
                    entity.PersonaggioId = temp.PersonaggioId;
                    entity.CodicePersonaggio = entity.CodicePersonaggio is not null ? entity.CodicePersonaggio : temp.CodicePersonaggio;
                    entity.NomePersonaggio = entity.NomePersonaggio is not null ? entity.NomePersonaggio : temp.NomePersonaggio;
                    entity.CostoPersonaggio = entity.CostoPersonaggio > 0 ? entity.CostoPersonaggio : temp.CostoPersonaggio;
                    entity.CategoriaPersonaggio = entity.CategoriaPersonaggio > 0 ? entity.CategoriaPersonaggio : temp.CategoriaPersonaggio;
                    entity.FotoPersonaggio = entity.FotoPersonaggio is not null ? entity.FotoPersonaggio : temp.FotoPersonaggio;
                    entity.SquadraRif = entity.SquadraRif is not null ? entity.SquadraRif : temp.SquadraRif;
                    entity.SquadraRifNavigation = entity.SquadraRifNavigation is not null ? entity.SquadraRifNavigation : temp.SquadraRifNavigation;

                    ctx.Entry(temp).CurrentValues.SetValues(entity);
                    ctx.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return false;
        }

        public Personaggio? GetByCodice(string codice)
        {
            return ctx.Personaggios.FirstOrDefault(p => p.CodicePersonaggio == codice);
        }

        public bool InserisciPersonaggioInSquadra(string codiceS, string codiceP)
        {
            try
            {
                Squadra s = ctx.Squadras.FirstOrDefault(s=>s.CodiceSquadra==codiceS);
                Personaggio p = ctx.Personaggios.FirstOrDefault(p => p.CodicePersonaggio == codiceP);

                Personaggio pMod = new Personaggio();
                
                    pMod.PersonaggioId = p.PersonaggioId;
                    pMod.CodicePersonaggio = p.CodicePersonaggio;
                    pMod.NomePersonaggio = p.NomePersonaggio;
                    pMod.CostoPersonaggio = p.CostoPersonaggio;
                    pMod.CategoriaPersonaggio = p.CategoriaPersonaggio;
                    pMod.FotoPersonaggio = p.FotoPersonaggio;
                    pMod.SquadraRif = s.SquadraId;
                    pMod.SquadraRifNavigation = s;
            

                ctx.Entry(p).CurrentValues.SetValues(pMod);
                ctx.SaveChanges();
                s.Personaggi.Add(p);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public List<Personaggio> GetPersonaggiInSquadra(string codice)
        {
            Squadra s = ctx.Squadras.FirstOrDefault(s=>s.CodiceSquadra==codice);

            List<Personaggio> personaggi = new List<Personaggio>();

            if (s.Personaggi != null)
            {
                foreach (Personaggio p in s.Personaggi)
                {
                    personaggi.Add(p);
                }
            }

            return personaggi;
        }
    }
}
