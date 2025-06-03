using System.ServiceModel;
using PokemonAPi.Dtos;

namespace PokemonAPi.Services;
[ServiceContract(Name ="PokemonService",Namespace ="http://pokemon-api/pokemon-service")]
    public interface IPokemonService{
        [OperationContract ]
        Task<PokemonResponseDto> GetPokemonById(Guid id,CancellationToken cancellationToken);

        [OperationContract ]
        Task<bool> DeletePokemonById(Guid id, CancellationToken cancellationToken);

        [OperationContract]
        Task<PokemonResponseDto> CreatePokemon(CreatePokemonDto createPokemonDto,CancellationToken cancellationToken);

        [OperationContract]
        Task<PokemonResponseDto> UpdatePokemon(UpdatePokemonDto pokemon,CancellationToken cancellationToken);

        [OperationContract]
         Task<List<PokemonResponseDto>> GetPokemonByName(string name,CancellationToken cancellationToken);
    }
