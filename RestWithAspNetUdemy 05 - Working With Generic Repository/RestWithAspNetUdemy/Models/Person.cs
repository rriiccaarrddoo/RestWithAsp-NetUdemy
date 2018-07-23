using RestWithAspNetUdemy.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNetUdemy.Models
{
    [Table("Person")]
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
