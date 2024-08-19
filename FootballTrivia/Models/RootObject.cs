using System.Xml.Serialization;

namespace FootballTrivia.Models
{
	public class Rootobject
	{
		public string? Get { get; set; }
		public Parameters? Parameters { get; set; }
		public object[]? Errors { get; set; }
		public int Results { get; set; }
		public Paging? Paging { get; set; }
		public Response[]? Response { get; set; }
	}
}