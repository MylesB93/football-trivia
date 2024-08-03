namespace FootballTrivia.Models
{
	public class Standing
	{
		public int Rank { get; set; }
		public Team Team { get; set; }
		public int Points { get; set; }
		public int GoalsDiff { get; set; }
		public string Group { get; set; }
		public string Form { get; set; }
		public All All { get; set; }
		public Home Home { get; set; }
		public Away Away { get; set; }
		public DateTime Update { get; set; }
	}
}
