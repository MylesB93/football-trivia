namespace FootballTrivia.Models
{
	public class League
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Country { get; set; }
		public int Season { get; set; }
		public Standing[][]? Standings { get; set; }
	}
}
