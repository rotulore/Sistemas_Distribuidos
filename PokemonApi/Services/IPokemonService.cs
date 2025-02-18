using System.ServiceModel;
using PokemonAPi.Dtos;

namespace PokemonAPi.Services;
[ServiceContract(Name ="PokemonService",Namespace ="http://pokemon-api/pokemon-service")]
    public interface IPokemonService{
        [OperationContract ]
        Task<PokemonResponseDto> GetPokemonById(Guid id,CancellationToken cancellationToken);
    }
