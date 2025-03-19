using System.Runtime.Serialization;
using PokemonApi.Dtos;

namespace PokemonAPi.Dtos;
[DataContract(Name ="UpdatePokemonDto", Namespace="http://hobbie-api/hobbie-service")]

public class UpdateHobbieDto:HobbieCommon
{
      [DataMember(Name = "Id", Order = 3)]
        public int Id { get; set; }
}