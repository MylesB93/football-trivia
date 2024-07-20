using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballTrivia.Areas.Quiz.Pages
{
	public class IndexModel : PageModel
	{
		public Dictionary<string, string[]>? Questions { get; set; }

		public void OnGet()
		{
			Questions = new Dictionary<string, string[]>
			{
				{ "How old is Neymar?", ["32", "27", "31"] },
				{ "Who is the all the time leading Premier League goal scorer?", ["Alan Shearer", "Michael Owen", "Wayne Rooney"] },
				{ "Who does Harry Kane play for?", ["Bayern Munchen", "Tottenham Hotspur", "Leicester City"] },
			};
		}
	}
}
