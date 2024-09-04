using FootballTrivia.Data;
using FootballTrivia.Interfaces;

namespace FootballTrivia.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly FootballTriviaContext _dbContext;
		public UserRepository(FootballTriviaContext dbContext) 
		{
			_dbContext = dbContext;
		}

		public int GetHighScore(string userName)
		{
			var score = 0;
			var user = _dbContext.Users.Where(u => u.UserName == userName).FirstOrDefault();
			if (user != null)
			{
				score = user.HighScore;
			}
			
			return score;
		}
	}
}
