using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductProject.Data;
using ProductProject.Repository.Interface;
using ProductProject.UnitOfWork.Interface;

namespace ProductProject.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext dataContext;
        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }


        public void Add(T item)
        {
            this.dataContext.Set<T>().Add(item);
        }

        public void Edit(T item)
        {
            this.dataContext.Entry(item).State = EntityState.Modified;
        }

        public T Find(int id)
        {
            return this.dataContext.Set<T>().Find(id);
        }

        public IQueryable<T> List()
        {
            return this.dataContext.Set<T>();
        }

        public void Remove(T item)
        {
            this.dataContext.Set<T>().Remove(item);
        }
    }
}