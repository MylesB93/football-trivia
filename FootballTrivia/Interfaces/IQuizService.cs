namespace FootballTrivia.Interfaces
{
	public interface IQuizService
	{
		Task<Dictionary<string, string[]>> GetQuizQuestionsAsync(string season = "2023");
        Task GetSpeedRoundQuestionsAsync(string season = "2023");
    }
}
