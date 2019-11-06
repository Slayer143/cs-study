using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Formatters;
using lesson_22.CitiesDataStore.Core;
using MyCitiesDataStore = lesson_22.CitiesDataStore.InMemory.CitiesDataStore;

namespace lesson_22
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
				.SetCompatibilityVersion(
					CompatibilityVersion.Version_2_2)
				.AddMvcOptions(
				o => o.OutputFormatters.Add(
					new XmlDataContractSerializerOutputFormatter()));

			services.AddSingleton<ICitiesDataStore>(
				new MyCitiesDataStore());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStatusCodePages();

			//app.UseMvc(
			//	config =>
			//	config.MapRoute(
			//		name : "Default",
			//		template : "{controller}/{action}/{id?}",
			//		defaults : new
			//		{
			//			controller = "Cities",
			//			action = "GetCities"
			//		}));

			app.UseMvc();
		}
	}
}
