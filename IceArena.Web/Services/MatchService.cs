using AutoMapper;
using IceArena.Data.Models;
using IceArena.Web.Interfaces;
using IceArena.Web.Models;

namespace IceArena.Web.Services
{
    public class MatchService : IMatchService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public MatchService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        
        public async Task<List<MatchDto>> GetMatchesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                
                // загрузка данных из апишки
                var response = await _httpClient.GetFromJsonAsync<List<Match>>("Match", cancellationToken);

                // проверка
                if (response == null) return new List<MatchDto>();
                Console.WriteLine($"Ответ от API: {System.Text.Json.JsonSerializer.Serialize(response)}");

                // маппим
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
