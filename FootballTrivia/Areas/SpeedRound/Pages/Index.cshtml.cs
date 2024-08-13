using FootballTrivia.Interfaces;
using FootballTrivia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballTrivia.Areas.SpeedRound.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IQuizService _quizService;

        public List<string>? Standings;

        public IndexModel(IQuizService quizService)
        {
            _quizService = quizService;
        }

        public async Task OnGetAsync(string lid, string year)
        {
            Standings = await _quizService.GetSpeedRoundQuestionsAsync(lid, year);
        }
    }
}
