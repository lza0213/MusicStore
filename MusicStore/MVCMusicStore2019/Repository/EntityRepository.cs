using MVCMusicStore2019.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Repository
{
    public class EntityRepository<T>:IEntityRepository<T> where T:class, IEntity,new()
    {
        readonly DbContext _context;
        public EntityRepository(MusicDbContext context)
        {
            _context = context;
        }
        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
        public virtual void Create(T entity)
        {
            DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
        }
        public virtual void Save()
        {
            _context.SaveChanges();
        }
        public virtual void AddAndSave(T entity)
        {
            Create(entity);
            Save();
        }

        public virtual void Edit(T entity)
        {

            if (entity == null)
            {
                throw new ArgumentException("entity实体为空");
            }
            DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
            RemoveHoldingEntityInContext(entity);
            _context.Set<T>().Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
            Save();
        }
        private Boolean RemoveHoldingEntityInContext(T entity)
        {
            var objContext = ((IObjectContextAdapter)_context).ObjectContext;
            var objSet = objContext.CreateObjectSet<T>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);
            Object foundEntity;
            var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);
            if(exists)
            {
                objContext.Detach(foundEntity);
            }
            return (exists);
        }
     
        public virtual T GetSingleById(Guid id)
        {
            var entity = _context.Set<T>().Where(x => x.ID == id).DefaultIfEmpty<T>().First();
            if (entity != null)
                return _context.Set<T>().Where(x => x.ID == id).First();
            else
                return null;
        }
        public bool Delete(Guid id)
        {
            var dbSet = _context.Set(typeof(T));
            bool returnStatus = true;
            var entity = dbSet.Find(id);
            if(entity==null)
            {
                returnStatus = false;
                return returnStatus;
            }
            else
            {
                try
                {
                    dbSet.Remove(entity);
                    _context.SaveChanges();
                    return returnStatus;
                }
                catch
                {
                    returnStatus = false;
                }
            }
            return returnStatus;
        }

        public IQueryable<T1> GetRelevance<T1>()
        {
            var dbList = _context.Set(typeof(T1));
            var query = dbList as IQueryable<T1>;
            return query;
        }

        public virtual T1 GetSingleReleVvance<T1>(Guid id)
        {
            var dbSet = _context.Set(typeof(T1));
            return (T1)dbSet.Find(id);
        }
    }
}