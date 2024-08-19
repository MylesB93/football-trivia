using FootballTrivia.Interfaces;
using FootballTrivia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballTrivia.Areas.SpeedRound.Pages
{
	public class IndexModel : PageModel
	{
		private readonly IQuizService _quizService;
		private readonly IUserService _userService;

		public List<string?>? Standings;
		public int HighScore { get; set; } // TODO: Remember to update this whenever the user gets a new high score

		public IndexModel(IQuizService quizService, IUserService userService)
		{
			_quizService = quizService;
			_userService = userService;
		}

		public async Task OnGetAsync(string lid, string year = "2023")
		{
			Standings = await _quizService.GetSpeedRoundQuestionsAsync(lid, year); //TODO: Figure out why warning is being thrown here 

			if (User?.Identity?.Name != null)
				HighScore = _userService.GetHighScore(User.Identity.Name);
		}
	}
}
