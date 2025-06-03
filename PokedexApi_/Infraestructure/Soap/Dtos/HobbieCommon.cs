
using System.Runtime.Serialization;
using  PokedexApi_.Infraestructure.Soap.Dtos;
namespace  PokedexApi_.Infraestructure.Soap.Dtos;
[DataContract(Name ="PokemonCommon", Namespace="http://hobbie-api/hobbie-service")]
[KnownType(typeof(CreateHobbieDto))]
[KnownType(typeof(UpdateHobbieDto))]

public class HobbieCommon
{
      [DataMember(Name = "Name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "Top", Order = 2)]
        public int Top { get; set; }
}