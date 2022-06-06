using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using BasketFormation.Persitence.ContextsDB;
using Microsoft.Extensions.DependencyInjection;

namespace BasketFormation.API
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                // Takes all of our migrations files and apply them against the database in case they are not implemented
                serviceScope.ServiceProvider.GetService<RepositoryContext>().Database.Migrate();
            }
        }
    }
}
