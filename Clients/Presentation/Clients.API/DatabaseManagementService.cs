using Microsoft.AspNetCore.Builder;
using Clients.Persistence.ContextsDB;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Clients.Persistence
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                // Takes all of our migrations files and apply them against the database in case they are not implemented
                serviceScope.ServiceProvider.GetService<AccountContext>().Database.Migrate();
            }
        }
    }
}
