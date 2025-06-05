using AutoMapper;
using IceArena.Data.Models;
using IceArena.Web.Interfaces;
using IceArena.Web.Models;

namespace IceArena.Web.Services
{
    public class MatchServiceee : IMatchServiceee
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public MatchServiceee(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        
        public async Task<List<MatchDto>> GetMatchesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                
                var response = await _httpClient.GetFromJsonAsync<List<Match>>("Match", cancellationToken);

                if (response == null) return new List<MatchDto>();

                return _mapper.Map<List<MatchDto>>(response);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении матчей: {ex.Message}");
                return new List<MatchDto>();
            }
        }
    }
}
