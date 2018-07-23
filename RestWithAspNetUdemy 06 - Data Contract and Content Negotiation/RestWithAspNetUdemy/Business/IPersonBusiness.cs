using RestWithAspNetUdemy.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNetUdemy.Services
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(int Id);
        List<Person> FindAll(int page, int pagesize);
        Person Update(Person person);
        void Delete(int id);

    }
}
