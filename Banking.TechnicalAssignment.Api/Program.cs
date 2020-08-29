using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Respositories;
using Banking.TechnicalAssignment.Api.Core.Services;
using Banking.TechnicalAssignment.Api.Persistance.Repositories;
using Banking.TechnicalAssignment.Api.Persistance.Respositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Banking.TechnicalAssignment.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureServices((hostcontext, services) =>
                {
                    services.AddOptions();
                    services.AddSingleton<ILiteDbContext, LiteDbContext>();
                    services.Configure<LiteDbOptions>(hostcontext.Configuration.GetSection("LiteDbOptions"));

                    services.AddTransient<ICustomerService, CustomerService>();
                    services.AddTransient<IAccountService, AccountService>();
                    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                });
    }
}
