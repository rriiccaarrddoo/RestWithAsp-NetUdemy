using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithAspNetUdemy.Models;
using RestWithAspNetUdemy.Models.Context;
using RestWithAspNetUdemy.Repository;

namespace RestWithAspNetUdemy.Services.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository repository;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            this.repository = repository;
        }

        public Person Create(Person person)
        {
           return repository.Create(person);
        }

        public void Delete(int id)
        {
            repository.Delete(id);

        }

        public List<Person> FindAll(int page, int pagesize)
        {
            return repository.FindAll(page, pagesize);
        }

        public Person FindById(int id)
        {
            return repository.FindById(id);
        }

        public Person Update(Person personUpdate)
        {
            return repository.Update(personUpdate);
        }

    }
}
