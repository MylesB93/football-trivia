namespace FootballTrivia.Interfaces
{
	public interface IQuizService
	{
		Dictionary<string, string[]> GetQuizQuestions();
	}
}
