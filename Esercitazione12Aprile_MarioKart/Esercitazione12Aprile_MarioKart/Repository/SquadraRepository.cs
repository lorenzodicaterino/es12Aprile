using Esercitazione12Aprile_MarioKart.Model;
using Microsoft.IdentityModel.Tokens;

namespace Esercitazione12Aprile_MarioKart.Repository
{
    public class SquadraRepository : IRepository<Squadra>
    {

        private readonly Es12AprileContext ctx;

        public SquadraRepository(Es12AprileContext context)
        {
            ctx = context;
        }

        public Squadra? Get(int id)
        {
            return ctx.Squadras.FirstOrDefault(s=>s.SquadraId==id);
        }

        public IEnumerable<Squadra> GetAll()
        {
            return ctx.Squadras.ToList();
        }

        public Squadra? GetByCodice(string codice)
        {
            return ctx.Squadras.FirstOrDefault(s => s.CodiceSquadra == codice);
        }

        public bool Create(Squadra entity)
        {
            try
            {
                ctx.Squadras.Add(entity);
                    ctx.SaveChanges();
                    return true;
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public bool Delete(string codice)
        {
            try
            {
                ctx.Squadras.Remove(ctx.Squadras.FirstOrDefault(s=>s.CodiceSquadra==codice));
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public bool Update(Squadra entity)
        {
            Squadra? temp = this.GetByCodice(entity.CodiceSquadra);
            if(temp is not null)
            {
                try
                {
                    entity.SquadraId = temp.SquadraId;
                    entity.CodiceSquadra = entity.CodiceSquadra is not null ? entity.CodiceSquadra : temp.CodiceSquadra;
                    entity.NomeSquadra = entity.NomeSquadra is not null ? entity.NomeSquadra : temp.NomeSquadra;
                    entity.Crediti = entity.Crediti> 0 ? entity.Crediti : temp.Crediti;
                    entity.Personaggi = entity.Personaggi is not null ? entity.Personaggi : temp.Personaggi;

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

        public List<Personaggio> x (string codiceS)
        {
            List<Personaggio> per = new List<Personaggio>();

            foreach( Personaggio p in ctx.Personaggios.ToList())
            {
                if (p.SquadraRifNavigation.CodiceSquadra == codiceS)
                {
                    per.Add(p);
                }
            }

            return per;
        }

        public List<Personaggio> GetPersonaggiInSquadra(string codice)
        {
            List<Personaggio> per = new List<Personaggio>();

            foreach(Personaggio p in ctx.Personaggios.ToList())
            {
                if (p.SquadraRif == ctx.Squadras.FirstOrDefault(s=>s.CodiceSquadra==codice).SquadraId)
                {
                    per.Add(p);
                }
            }

            return per;
        }

    }
}
