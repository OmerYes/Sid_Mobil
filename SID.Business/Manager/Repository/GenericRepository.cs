using SID.Data.Model.ORM.Context;
using SID.Data.Model.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SID.Business.Manager.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Base
    {
        internal SIDContext Context;
        internal DbSet<TEntity> DbSet;
        public GenericRepository(SIDContext context)
        {
            this.Context = context;
            this.DbSet = Context.Set<TEntity>();

        }
        public TEntity Add(TEntity entity)
        {
            if(entity !=null)
            {
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.AddDate = DateTime.Now;
                DbSet.Add(entity);
                Context.SaveChanges();
            }
           
            return entity;
        }

        public TEntity AddCore(TEntity entity)
        {
            if (entity != null)
            {
                entity.IsDeleted = false;
                entity.AddDate = DateTime.Now;
                DbSet.Add(entity);
                Context.SaveChanges();
            }

            return entity;
        }
        

        public TEntity Find(int id)
        {
            return DbSet.Find(id);
        }

        public bool Any(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(q=> q.IsDeleted == false && q.IsActive).Any(exp);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(q => q.IsDeleted == false && q.IsActive).FirstOrDefault(exp);
        }


        public TEntity FirstOrDefaultCore(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(q => q.IsDeleted == false).FirstOrDefault(exp);
        }

        public TEntity FirstOrDefaultAll(Expression<Func<TEntity, bool>> lambda)
        {
            return DbSet.FirstOrDefault(lambda);


        }

        public List<TEntity> GetAll()
        {
            return DbSet.Where(q => q.IsDeleted == false && q.IsActive).ToList();
        }

        public IQueryable<TEntity> GetAllQuery()
        {
            return DbSet.Where(q => q.IsDeleted == false && q.IsActive);
        }


        public IQueryable<TEntity> GetAllQuerableWithQuery(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(q => q.IsDeleted == false && q.IsActive).Where(exp);
        }

        public bool Remove(int id)
        {
            
                TEntity entity = DbSet.FirstOrDefault(x => x.ID == id);
                if (entity != null)
                {
                    return true;
                }
            
                return false;
            
        }

        public TEntity Delete(int id)
        {
            TEntity entity = DbSet.FirstOrDefault(x => x.ID == id);
            entity.IsDeleted = true;
            Context.SaveChanges();

            return entity;

        }

        public void Update(TEntity entity)
        {
            if (entity != null)
            {
                var _entity = DbSet.Find(entity.ID);
                Context.Entry(_entity).CurrentValues.SetValues(entity);
                Context.SaveChanges();
            }
        }

        public List<TEntity> GetByID(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(x => x.IsDeleted == false && x.IsActive).Where(exp).ToList();

        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
