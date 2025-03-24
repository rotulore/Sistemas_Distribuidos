using System.Runtime.Serialization;
using  PokedexApi_.Infraestructure.Soap.Dtos;

namespace  PokedexApi_.Infraestructure.Soap.Dtos;
[DataContract(Name ="UpdatePokemonDto", Namespace="http://hobbie-api/hobbie-service")]

public class UpdateHobbieDto:HobbieCommon
{
      [DataMember(Name = "Id", Order = 3)]
        public int Id { get; set; }
}