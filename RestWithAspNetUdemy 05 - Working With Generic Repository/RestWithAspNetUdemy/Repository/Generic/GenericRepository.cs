using Microsoft.EntityFrameworkCore;
using RestWithAspNetUdemy.Models.Base;
using RestWithAspNetUdemy.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNetUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext context;
        // Declaração de um dataset genérico
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            this.context = context;
            this.dataset = context.Set<T>();
        }

        public T Create(T entity)
        {
            try
            {
                dataset.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return entity;
        }

        public void Delete(int id)
        {
            try
            {
                var entity = FindById(id);

                if (entity != null)
                {
                    dataset.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<T> FindAll(int page = 1, int pagesize = 4)
        {
            List<T> entity = dataset
                                .OrderBy(p=>p.Id)
                                .Skip( (page -1) * pagesize )
                                .Take(pagesize)
                                .ToList();
            return entity;
        }

        public T FindById(int id)
        {
            T entity = dataset.SingleOrDefault(p => p.Id == id);

            return entity;
        }

        public T Update(T entityUpdate)
        {
            try
            {
                var entity = FindById(entityUpdate.Id);

                if (entity != null)
                {
                    context.Entry(entity).CurrentValues.SetValues(entityUpdate);
                    context.SaveChanges();
                }
                else
                {
                    entityUpdate = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return entityUpdate;
        }

    }
}
