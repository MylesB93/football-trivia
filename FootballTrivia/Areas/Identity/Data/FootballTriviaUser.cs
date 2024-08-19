using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FootballTrivia.Areas.Identity.Data;

// Add profile data for application users by adding properties to the FootballTriviaUser class
public class FootballTriviaUser : IdentityUser
{
	public int HighScore { get; set; } = 0;
}

