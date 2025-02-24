using System.ServiceModel;
using PokemonAPi.Dtos;
[ServiceContract(Name ="JosueUribeHobbiesService",Namespace ="http://hobbie-api/hobbie-service")]
public interface IHobbieService
{
        [OperationContract ]
        Task<HobbiesResponseDto> GetHobbieById(int id,CancellationToken cancellationToken);

        [OperationContract ]
        Task<bool> DeleteHobbieById(int id, CancellationToken cancellationToken);

        [OperationContract]
         Task<List<HobbiesResponseDto>> GetHobbieByName(string name,CancellationToken cancellationToken);

}