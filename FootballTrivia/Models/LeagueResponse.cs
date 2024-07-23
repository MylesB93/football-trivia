using System.Xml.Serialization;

namespace FootballTrivia.Models
{
	[XmlRoot("response")]
	public class LeagueResponse
	{
		[XmlArrayItem("league")]
		public List<League>? Leagues { get; set; }
	}
}
