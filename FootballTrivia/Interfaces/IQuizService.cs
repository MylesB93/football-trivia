using FootballTrivia.Models;

namespace FootballTrivia.Interfaces
{
	public interface IQuizService
	{
		Task<Dictionary<string, string[]>> GetQuizQuestionsAsync(string year);
		Task<List<string?>?>? GetSpeedRoundQuestionsAsync(string league, string year);
    }
}
