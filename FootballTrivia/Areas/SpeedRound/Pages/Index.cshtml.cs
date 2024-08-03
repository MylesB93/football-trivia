using FootballTrivia.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballTrivia.Areas.SpeedRound.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IQuizService _quizService;

        public IndexModel(IQuizService quizService)
        {
            _quizService = quizService;
        }

        public async Task OnGetAsync()
        {
            await _quizService.GetSpeedRoundQuestionsAsync();
        }
    }
}
