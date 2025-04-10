using Messenger.Database.Context.Factory;

namespace Messenger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IApplicationContextFactory, ApplicationContextFactory>();
            // Add services to the container.

            builder.Services.AddControllersWithViews();

			builder.Services.AddControllers()
				.AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
