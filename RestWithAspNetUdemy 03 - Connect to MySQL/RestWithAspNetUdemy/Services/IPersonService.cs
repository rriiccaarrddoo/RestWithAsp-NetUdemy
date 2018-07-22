using RestWithAspNetUdemy.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNetUdemy.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(int Id);
        IQueryable<Person> FindAll();
        Person Update(Person person);
        void Delete(int id);

    }
}
