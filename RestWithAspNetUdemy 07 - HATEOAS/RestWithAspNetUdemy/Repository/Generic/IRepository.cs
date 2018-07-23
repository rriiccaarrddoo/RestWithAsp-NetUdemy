using RestWithAspNetUdemy.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T entity);
        T FindById(int id);
        List<T> FindAll(int page, int pagesize);
        T Update(T entity);
        void Delete(int id);
    }
}
