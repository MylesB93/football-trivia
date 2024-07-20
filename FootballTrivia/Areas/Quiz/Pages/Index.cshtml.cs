using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using FootballTrivia.Interfaces;

namespace FootballTrivia.Areas.Quiz.Pages
{
	public class IndexModel : PageModel
	{
		private readonly IQuizService _quizService;

		public Dictionary<string, string[]>? Questions { get; set; }

		public IndexModel(IQuizService quizService)
		{
			_quizService = quizService;
		}

		public void OnGet()
		{
			Questions = _quizService.GetQuizQuestions();
		}
	}
}
