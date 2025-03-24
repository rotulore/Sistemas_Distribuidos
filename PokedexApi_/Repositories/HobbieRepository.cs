
using System.ServiceModel;
using PokedexApi_.Models;
using PokedexApi_.Mappers;
using PokedexApi_.Infraestructure.Soap.Contracts;
namespace PokedexApi_.Repositories;

public class HobbieRepository: IHobbieRepository

{
    private readonly ILogger<HobbieRepository> _logger;
    private readonly IHobbieService _hobbieService;

    public HobbieRepository(ILogger<HobbieRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        var endpoint = new EndpointAddress(configuration.GetValue<string>("HobbieServiceEndpoint"));
        var binding = new BasicHttpBinding();
        _hobbieService = new ChannelFactory<IHobbieService>(binding, endpoint).CreateChannel();
    }

public async Task<Hobbie> GetHobbyByIdAsync(int id, CancellationToken cancellationToken)
{
    try
    {
        var hobbie = await _hobbieService.GetHobbieById(id, cancellationToken);
        return hobbie.ToModel();
    }
    catch (FaultException ex) when (ex.Message == "Hobbie not found")
    {
        _logger.LogError(ex, "Failed to get hobbie with id: {id}", id);
        return null;
    }}

    public async Task<List<Hobbie>> GetHobbiesByNameAsync(string name, CancellationToken cancellationToken)
    {
        try
        {
            var hobbies = await _hobbieService.GetHobbieByName(name, cancellationToken);
            return hobbies?.Select(h => h.ToModel()).ToList() ?? new List<Hobbie>();
        }
        catch (FaultException ex) when (ex.Message.Contains("Hobbie not found"))
        {
            _logger.LogError(ex, "Failed to get hobbie with name: {name}", name);
            return new List<Hobbie>();
        }
    }

}