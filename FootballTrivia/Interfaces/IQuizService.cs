using FootballTrivia.Models;

namespace FootballTrivia.Interfaces
{
	public interface IQuizService
	{
		Task<Dictionary<string, string[]>> GetQuizQuestionsAsync(string season = "2023");
		Task<List<string>?> GetSpeedRoundQuestionsAsync(string season = "2023");
    }
}
