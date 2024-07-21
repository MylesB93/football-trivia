using FootballTrivia.Interfaces;
using Microsoft.Extensions.Options;

namespace FootballTrivia.Services
{
	public class QuizService : IQuizService
	{
		private readonly IOptions<FootballDataConfiguration> _footballDataConfig;

		public QuizService(IOptions<FootballDataConfiguration> footballDataConfiguration)
		{
			_footballDataConfig = footballDataConfiguration;
		}

		public Dictionary<string, string[]> GetQuizQuestions()
		{
			var apiKey = _footballDataConfig.Value.FootballAPIKey;
			return new Dictionary<string, string[]>
			{
				{ "How old is Neymar?", ["32", "27", "31"] },
				{ "Who is the all the time leading Premier League goal scorer?", ["Alan Shearer", "Michael Owen", "Wayne Rooney"] },
				{ "Who does Harry Kane play for?", ["Bayern Munchen", "Tottenham Hotspur", "Leicester City"] },
			};
		}
	}
}