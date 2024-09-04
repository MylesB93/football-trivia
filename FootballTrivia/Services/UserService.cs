using FootballTrivia.Interfaces;

namespace FootballTrivia.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public int GetHighScore(string userName)
		{
			return _userRepository.GetHighScore(userName);
		}
    }
}
