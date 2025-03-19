using System.ServiceModel;
using  PokedexApi_.Infraestructure.Soap.Dtos;
namespace PokedexApi_.Infraestructure.Soap.Contracts;

[ServiceContract(Name ="JosueUribeHobbiesService",Namespace ="http://hobbie-api/hobbie-service")]
public interface IHobbieService
{
        [OperationContract ]
        Task<HobbiesResponseDto> GetHobbieById(int id,CancellationToken cancellationToken);

        [OperationContract ]
        Task<bool> DeleteHobbieById(int id, CancellationToken cancellationToken);

        [OperationContract]
         Task<List<HobbiesResponseDto>> GetHobbieByName(string name,CancellationToken cancellationToken);

        [OperationContract]
        Task<HobbiesResponseDto> CreateHobbie(CreateHobbieDto createHobbieDto,CancellationToken cancellationToken);

        [OperationContract]
        Task<HobbiesResponseDto> UpdateHobbie(UpdateHobbieDto hobbie,CancellationToken cancellationToken);
}
