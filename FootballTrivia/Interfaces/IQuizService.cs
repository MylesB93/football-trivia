using FootballTrivia.Models;

namespace FootballTrivia.Interfaces
{
	public interface IQuizService
	{
		Task<Dictionary<string, string[]>> GetQuizQuestionsAsync(string year = "2023");
		Task<List<string>?> GetSpeedRoundQuestionsAsync(string league, string year = "2023");
    }
}
