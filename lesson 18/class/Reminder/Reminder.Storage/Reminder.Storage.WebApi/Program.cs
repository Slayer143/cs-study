using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Reminder.Storage.WebApi
{
    public class Program
	{
		public static void Main(string[] args)
		{
            CreateDefaultBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateDefaultBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
	}
}
