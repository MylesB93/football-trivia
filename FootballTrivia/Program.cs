using Microsoft.EntityFrameworkCore;
using FootballTrivia.Data;
using FootballTrivia.Areas.Identity.Data;
using FootballTrivia.Email;
using Microsoft.AspNetCore.Identity.UI.Services;
using FootballTrivia.Interfaces;
using FootballTrivia.Services;

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

			var FootballDataConfiguration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddUserSecrets<Program>()
				.Build();
			builder.Services.Configure<FootballDataConfiguration>(FootballDataConfiguration.GetSection("FootballDataConfiguration"));

            builder.Services.AddTransient<IEmailSender, EmailSender>();
            builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

			builder.Services.AddScoped<IQuizService, QuizService>();
			builder.Services.AddScoped<IUserService, UserService>();

			builder.Services.AddHttpClient("FootballData", httpClient =>
			{
				httpClient.BaseAddress = new Uri("https://api-football-v1.p.rapidapi.com/v3/");
				httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "api-football-v1.p.rapidapi.com");
				httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", builder.Configuration["FootballDataConfiguration:FootballAPIKey"]);
			});

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
