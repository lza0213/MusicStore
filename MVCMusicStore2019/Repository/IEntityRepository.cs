using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore2019.Repository
{
    public interface IEntityRepository<T> where T:class,new()
    {
        IQueryable<T> GetAll();
        void Create(T entity);
        void AddAndSave(T entity);

        void Edit(T entity);
        T GetSingleById(Guid id);
        bool Delete(Guid id);
        IQueryable<T1> GetRelevance<T1>();
        T1 GetSingleReleVvance<T1>(Guid id);
    }
}
