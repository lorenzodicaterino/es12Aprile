namespace Esercitazione12Aprile_MarioKart.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T? Get(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(string codice);
        T? GetByCodice(string codice);
    }
}
