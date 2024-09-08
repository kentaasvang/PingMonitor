using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public static class ConfigureServices
{
    public static void AddDatabase(this IServiceCollection services)
    {

        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=app.db"));

        services.AddAuthorization();
    }

    public static void AddIdentity(this IServiceCollection services)
    {
        services.AddIdentityApiEndpoints<IdentityUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
    }
}
