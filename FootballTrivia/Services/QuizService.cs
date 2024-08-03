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

		public QuizService(IOptions<FootballDataConfiguration> footballDataConfiguration, IHttpClientFactory httpClientFactory)
		{
			_footballDataConfig = footballDataConfiguration;
			_httpClientFactory = httpClientFactory;
		}

		public async Task<Dictionary<string, string[]>> GetQuizQuestionsAsync(string season = "2023")
		{
			var apiKey = _footballDataConfig.Value.FootballAPIKey;

			var client = _httpClientFactory.CreateClient("FootballData");
			client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);

			var response = await client.GetAsync($"/v3/standings?league=39&season={season}");
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

		public Task GetSpeedRoundQuestionsAsync(string season = "2023")
		{
			return Task.CompletedTask;
		}
    }
}