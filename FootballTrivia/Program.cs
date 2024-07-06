using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FootballTrivia.Data;
namespace FootballTrivia
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
   var connectionString = builder.Configuration.GetConnectionString("FootballTriviaContextConnection") ?? throw new InvalidOperationException("Connection string 'FootballTriviaContextConnection' not found.");

   builder.Services.AddDbContext<FootballTriviaContext>(options => options.UseSqlServer(connectionString));

   builder.Services.AddDefaultIdentity<FootballTriviaUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<FootballTriviaContext>();

			// Add services to the container.
			builder.Services.AddRazorPages();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}
