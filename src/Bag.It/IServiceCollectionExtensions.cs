using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Bag.It.Services.Auth;
using Bag.It.Services.Users;
using Bag.It.Interfaces.Services.Auth;
using Bag.It.Interfaces.Services.Users;
using Bag.It.Models;

namespace Bag.It
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddBagIt(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<ApplicationContext>(options =>
                {
                    options.UseSqlServer(
                        configuration.GetConnectionString("BagItDatabase"),
                        builder =>
                        {
                            builder.MigrationsAssembly("Bag.It.Auth");
                            builder.EnableRetryOnFailure();
                        }
                    );
                })
                .AddTransient<IAuthenticationSevice, AuthenticationService>()
                .AddTransient<IUserService, UserService>();
    }
}