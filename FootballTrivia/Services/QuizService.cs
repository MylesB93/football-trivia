using FootballTrivia.Interfaces;

namespace FootballTrivia.Services
{
	public class QuizService : IQuizService
	{
		public Dictionary<string, string[]> GetQuizQuestions()
		{
			return new Dictionary<string, string[]>
			{
				{ "How old is Neymar?", ["32", "27", "31"] },
				{ "Who is the all the time leading Premier League goal scorer?", ["Alan Shearer", "Michael Owen", "Wayne Rooney"] },
				{ "Who does Harry Kane play for?", ["Bayern Munchen", "Tottenham Hotspur", "Leicester City"] },
			};
		}
	}
}