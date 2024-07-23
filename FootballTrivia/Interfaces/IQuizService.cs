namespace FootballTrivia.Interfaces
{
	public interface IQuizService
	{
		Task<Dictionary<string, string[]>> GetQuizQuestionsAsync();
	}
}
