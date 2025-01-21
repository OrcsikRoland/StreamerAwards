using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StreamerAwards.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        // Adatok lekérdezése
        IEnumerable<T> GetAll();
        T? GetById(string id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        // Adatok módosítása
        void Add(T entity);
        void Update(T entity);
        void Delete(string id);

        // Mentés
        void SaveChanges();
    }
}
