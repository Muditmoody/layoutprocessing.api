using Serilog;
using PWCLayoutProcessingWebApp.Data;
using PWCLayoutProcessingWebApp.BusinessLogic;

namespace PWCLayoutProcessingWebApp
{
    public static class Program
    {
        /// <summary>
        /// Entry point for application
        /// </summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(/*options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true*/).AddNewtonsoftJson();
            builder.Services.AddControllersWithViews();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<DatabaseProvider>();
            builder.Services.AddScoped<QueryBuilder>();
            builder.Services.AddDbContext<LayoutProcessingDbContext>(
            //options =>  options.UseSqlServer("Server=LAPTOP-HMF8Q5ET\\SQLEXPRESS;Initial Catalog=PWC_LayoutProcessing;Integrated Security=SSPI;TrustServerCertificate=True")
            );

            var logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build())
                            .Enrich.FromLogContext()
                            .WriteTo.Seq("http://localhost:5341/")
                            .CreateLogger();
            builder.Logging.AddSerilog(logger);

            var app = builder.Build();
            app.UseStaticFiles();
            //app.Urls.Add("https://localhost:5001/");
            //app.Urls.Add("http://localhost:6001/");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.MapControllers();
            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}