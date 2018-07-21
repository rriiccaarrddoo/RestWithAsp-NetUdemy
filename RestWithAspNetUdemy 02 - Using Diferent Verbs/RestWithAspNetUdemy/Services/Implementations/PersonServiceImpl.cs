using System;
using System.Collections.Generic;
using System.Threading;
using RestWithAspNetUdemy.Models;

namespace RestWithAspNetUdemy.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                people.Add(new Person { Id = GenerateId(), FirstName = "Nome" + i,
                    LastName = "Sobrenome" + i, Address = "Bairro" + i, Gender = GetGender(i) });
            }

            return people;
        }

        public Person FindById(long id)
        {
            return new Person { Id = id, FirstName = "Ricardo",
                LastName = "Oliveira", Address = "Vila Barreto", Gender = "Male" };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private string GetGender(int i)
        {
            if (i / 2 == 0)
            {
                return "Male";
            }

            return "Female";
        }

        private long GenerateId()
        {
            return Interlocked.Increment(ref count);
        }

    }
}
