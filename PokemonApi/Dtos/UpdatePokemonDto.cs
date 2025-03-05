using System.Runtime.Serialization;
using PokemonApi.Dtos;

namespace PokemonAPi.Dtos;
[DataContract(Name ="UpdatePokemonDto", Namespace="http://pokemon-api/pokemon-service")]
    public class UpdatePokemonDto:PokemonCommon
    {
    [DataMember(Name="Id",Order =5)]
    public Guid Id { get; set; }
    
    }
