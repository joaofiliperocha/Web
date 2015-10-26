using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Models.Respositories
{
    public class Repository<T> : IDisposable where T : class 
    {
        private ModelDataContext context = new ModelDataContext();
        private bool disposed = false;

        protected DbSet<T> DbSet { get; set; }

        public Repository()
        {
        
            DbSet = context.Set<T>();
        }

        public List<T> GetAll()
        {
            context.Database.Log = Console.Write;

            return DbSet.ToList();
            
        }


        public T Get(long id)
        {
            context.Database.Log = Console.Write; 
            return DbSet.Find(id);

        }

        public void Delete(T entity)
        {
            context.Database.Log = Console.Write; 
            DbSet.Remove(entity);
            SaveChanges();
        }

        public void DeleteByID(long id)
        {
            context.Database.Log = Console.Write; 
            DbSet.Remove(this.Get(id));
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
            DbSet.Add(entity);
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
