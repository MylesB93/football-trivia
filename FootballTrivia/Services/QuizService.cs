﻿using FootballTrivia.Interfaces;
using Microsoft.Extensions.Options;

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

		public Dictionary<string, string[]> GetQuizQuestions()
		{
			var apiKey = _footballDataConfig.Value.FootballAPIKey;

			var client = _httpClientFactory.CreateClient("FootballData");
			client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);

			return new Dictionary<string, string[]>
			{
				{ "How old is Neymar?", ["32", "27", "31"] },
				{ "Who is the all the time leading Premier League goal scorer?", ["Alan Shearer", "Michael Owen", "Wayne Rooney"] },
				{ "Who does Harry Kane play for?", ["Bayern Munchen", "Tottenham Hotspur", "Leicester City"] },
			};
		}
	}
}