using FootballTrivia.Interfaces;
using FootballTrivia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballTrivia.Areas.SpeedRound.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IQuizService _quizService;

        public Standing[][]? Standings;

        public IndexModel(IQuizService quizService)
        {
            _quizService = quizService;
        }

        public async Task OnGetAsync()
        {
            Standings = await _quizService.GetSpeedRoundQuestionsAsync();
        }
    }
}
