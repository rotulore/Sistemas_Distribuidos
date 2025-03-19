using System.Runtime.Serialization;

namespace  PokedexApi_.Infraestructure.Soap.Dtos;

[DataContract(Name ="PokemonResponseDto",Namespace ="http://pokemon-api/pokemon-service")]
public class PokemonResponseDto
{
    [DataMember(Name ="Id", Order = 1)] 
   public Guid Id{get; set;}
    [DataMember(Name ="Name", Order = 2)]
    public string Name{get;set;}
    [DataMember(Name ="Type", Order = 3)]
    public string Type{get;set;}
    [DataMember(Name ="Level", Order = 4)]
    public int Level{get;set;}
    [DataMember(Name ="Stats", Order = 5)]
    public StatsDto Stats{get;set;}

}