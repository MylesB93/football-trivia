using FootballTrivia.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using FootballTrivia.Models;

namespace FootballTrivia.Services
{
	public class QuizService : IQuizService
	{
		private readonly IOptions<FootballDataConfiguration> _footballDataConfig;
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly HttpClient _httpClient;

		public QuizService(IOptions<FootballDataConfiguration> footballDataConfiguration, IHttpClientFactory httpClientFactory)
		{
			_footballDataConfig = footballDataConfiguration;
			_httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("FootballData");
        }

		public async Task<Dictionary<string, string[]>> GetQuizQuestionsAsync(string season = "2023")
		{
			var response = await _httpClient.GetAsync($"/v3/standings?league=39&season={season}");
			var content = await response.Content.ReadAsStringAsync();
			var standings = JsonConvert.DeserializeObject<Rootobject>(content)?.Response?.FirstOrDefault()?.League?.Standings;

			//dummy questions
			return new Dictionary<string, string[]>
			{
				{ "How old is Neymar?", ["32", "27", "31"] },
				{ "Who is the all the time leading Premier League goal scorer?", ["Alan Shearer", "Michael Owen", "Wayne Rooney"] },
				{ "Who does Harry Kane play for?", ["Bayern Munchen", "Tottenham Hotspur", "Leicester City"] },
			};
		}

		public async Task<List<string>?> GetSpeedRoundQuestionsAsync(string league, string season = "2023")
		{
            var response = await _httpClient.GetAsync($"/v3/standings?league={league}&season={season}");
            var content = await response.Content.ReadAsStringAsync();
            var standings = JsonConvert.DeserializeObject<Rootobject>(content)?.Response?.FirstOrDefault()?.League?.Standings?.FirstOrDefault()?.Select(s => s.Team.Name).ToList();

            return standings;
		}
    }
}