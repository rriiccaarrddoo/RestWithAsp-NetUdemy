using RestWithAspNetUdemy.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RestWithAspNetUdemy.Models
{
    [Table("Person")]
    public class Person : BaseEntity
    {
        [DataMember(Name = "Nome")]
        public string FirstName { get; set; }
        [DataMember(Name = "Sobrenome")]
        public string LastName { get; set; }
        [DataMember(Name = "Endereço")]
        public string Address { get; set; }
        [DataMember(Name = "Genero")]
        public string Gender { get; set; }
    }
}
