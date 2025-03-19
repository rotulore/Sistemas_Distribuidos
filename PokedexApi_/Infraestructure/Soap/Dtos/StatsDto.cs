using System.Runtime.Serialization;

namespace  PokedexApi_.Infraestructure.Soap.Dtos;
[DataContract(Name ="StatsDto",Namespace ="http://pokemon-api/pokemon-service")]
public class StatsDto
{
    [DataMember(Name ="Attack",Order =1)]
    public int Attack{get;set;}
    [DataMember(Name ="Defense",Order =2)]
      public int Defense{get;set;}
      [DataMember(Name ="Speed",Order =3)]
        public int Speed{get;set;}

         [DataMember(Name = "Health", Order = 4)]  // Agregado Health
    public int Health { get; set; }


}