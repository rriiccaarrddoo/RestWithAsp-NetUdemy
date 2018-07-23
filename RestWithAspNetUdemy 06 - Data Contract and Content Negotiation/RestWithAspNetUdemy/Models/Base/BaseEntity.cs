using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RestWithAspNetUdemy.Models.Base
{
    // Se usar DataContract é necessário mapear todas as propriedades a serem expostas com DataMember
    //[DataContract]
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "Identificador")]
        public int Id { get; set; }

        [DataMember(Name = "DataEHora")]
        public DateTime? TimeStamp { get; set; }
    }
}
