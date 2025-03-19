using System.Runtime.Serialization;
using  PokedexApi_.Infraestructure.Soap.Dtos;

namespace  PokedexApi_.Infraestructure.Soap.Dtos;
[DataContract(Name ="UpdatePokemonDto", Namespace="http://pokemon-api/pokemon-service")]
    public class UpdatePokemonDto:PokemonCommon
    {
    [DataMember(Name="Id",Order =5)]
    public Guid Id { get; set; }
    
    }
