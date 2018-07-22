using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithAspNetUdemy.Models;
using RestWithAspNetUdemy.Models.Context;

namespace RestWithAspNetUdemy.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;
        private MySQLContext context;

        public PersonServiceImpl(MySQLContext context)
        {
            this.context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                context.People.Add(person);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return person;
        }

        public void Delete(int id)
        {
            try
            {
                var person = FindById(id);

                if (person != null)
                {
                    context.People.Remove(person);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public IQueryable<Person> FindAll()
        {
            IQueryable<Person> people = context.People.Take(10);
            return people;
        }

        public Person FindById(int id)
        {
            Person person = context.People.SingleOrDefault(p => p.Id == id);

            return person;
        }

        public Person Update(Person personUpdate)
        {
            try
            {
                var person = FindById(personUpdate.Id);

                if (person != null)
                {
                    context.Entry(person).CurrentValues.SetValues(personUpdate);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return personUpdate;
        }

        private string GetGender(int i)
        {
            if (i / 2 == 0)
            {
                return "Male";
            }

            return "Female";
        }

        private int GenerateId()
        {
            return Interlocked.Increment(ref count);
        }

    }
}
