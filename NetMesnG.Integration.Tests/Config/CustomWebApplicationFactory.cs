using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace NetMesnG.Integration.Tests.Config
{
    /// <summary>
    /// Using this factory for configure customisation.
    /// </summary>
    /// <typeparam name="TStartup"></typeparam>
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Get service => check for exists => remove => crete new db context.
                // var descriptor = services.SingleOrDefault(
                //     d => d.ServiceType ==
                //          typeof(DbContextOptions<ApplicationDbContext>));

                // services.Remove(descriptor);
                //
                // services.AddDbContext<ApplicationDbContext>(options =>
                // {
                //     options.UseInMemoryDatabase("InMemoryDbForTesting");
                // });

                // var sp = services.BuildServiceProvider();
                //
                // using (var scope = sp.CreateScope())
                // {
                //     var scopedServices = scope.ServiceProvider;
                //     var db = scopedServices.GetRequiredService<ApplicationDbContext>();
                //     var logger = scopedServices
                //         .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();
                //
                //     db.Database.EnsureCreated();
                //
                //     try
                //     {
                //         Utilities.InitializeDbForTests(db);
                //     }
                //     catch (Exception ex)
                //     {
                //         logger.LogError(ex, "An error occurred seeding the " +
                //                             "database with test messages. Error: {Message}", ex.Message);
                //     }
                // }
            });
        }
    }
}