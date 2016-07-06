using Framework.DAL.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Framework.DAL.Model.Repositories
{
    public class Repository<T> : IDisposable where T : class
    {
        private ModelContext context = new ModelContext();
        private bool disposed = false;

        protected DbSet<T> DBSet { get; set; }

        public Repository()
        {

            this.DBSet = context.Set<T>();
        }

        public List<T> GetAll()
        {
            context.Database.Log = Console.Write;

            return this.DBSet.ToList();

        }


        public T Get(long id)
        {
            context.Database.Log = Console.Write;
            return this.DBSet.Find(id);

        }

        public void Delete(T entity)
        {
            context.Database.Log = Console.Write;
            this.DBSet.Remove(entity);
            SaveChanges();
        }

        public void DeleteByID(long id)
        {
            context.Database.Log = Console.Write;
            this.DBSet.Remove(this.Get(id));
            SaveChanges();
        }

        public void Update(T entity)
        {
            context.Database.Log = Console.Write;
            context.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public void Insert(T entity)
        {
            context.Database.Log = Console.Write;
            this.DBSet.Add(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            context.Database.Log = Console.Write;
            context.SaveChanges();
        }



        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}