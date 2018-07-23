using RestWithAspNetUdemy.Models;
using RestWithAspNetUdemy.Models.Context;
using RestWithAspNetUdemy.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Repository.Implementations
{
    public class PersonRepositoryImpl : GenericRepository<Person> , IPersonRepository
    {
        public PersonRepositoryImpl(MySQLContext context) : base(context) { }
    }
}
