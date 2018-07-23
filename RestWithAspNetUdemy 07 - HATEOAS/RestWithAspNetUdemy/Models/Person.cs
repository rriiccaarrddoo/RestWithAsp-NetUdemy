using RestWithAspNetUdemy.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Tapioca.HATEOAS;

namespace RestWithAspNetUdemy.Models
{
    [Table("Person")]
    public class Person : BaseEntity, ISupportsHyperMedia
    {
        [DataMember(Name = "Nome")]
        public string FirstName { get; set; }
        [DataMember(Name = "Sobrenome")]
        public string LastName { get; set; }
        [DataMember(Name = "Endereço")]
        public string Address { get; set; }
        [DataMember(Name = "Genero")]
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
