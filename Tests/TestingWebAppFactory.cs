using HTMLServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
        public class TestingWebAppFactory<T> : WebApplicationFactory<Startup>
        {
            protected override void ConfigureWebHost(IWebHostBuilder builder)
            {
                builder.ConfigureServices(services =>
                {
                    var dbContext = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<DataAccess.Database>));

                    if (dbContext != null)
                        services.Remove(dbContext);

                    var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                    services.AddDbContext<DataAccess.Database>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryEmployeeTest");
                        options.UseInternalServiceProvider(serviceProvider);
                    });
                    var sp = services.BuildServiceProvider();

                    using (var scope = sp.CreateScope())
                    {
                        using (var appContext = scope.ServiceProvider.GetRequiredService<DataAccess.Database>())
                        {
                            try
                            {
                                appContext.Database.EnsureCreated();
                            }
                            catch (Exception ex)
                            {
                                //Log errors
                                throw;
                            }
                            appContext.Websites.Add(new Common.Website() { OwnerId = "testOwnerId", Id = "testId", Url = "testUrl" });
                            appContext.Pages.Add(new Common.Page() {Id = "pageId", Name = "pageName", Objects = new List<Common.HTMLObjects>() });
                            appContext.SaveChanges();
                        }
                    }
                });
            }
        }
    
}
