using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using MyFitness.Data;
using System.Reflection;
using MyFitness.Data.Migrations;
using MyFitness.Common.Constants;

[assembly: OwinStartup(typeof(MyFitness.Server.Api.Startup))]

namespace MyFitness.Server.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyFitnessDbContext, Configuration>());
            AutomapperConfig.RegisterMappings(Assembly.Load(Assemblies.MyFitnessServerApi));

            ConfigureAuth(app);
        }
    }
}
