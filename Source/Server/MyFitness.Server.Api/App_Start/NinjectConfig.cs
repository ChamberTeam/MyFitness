namespace MyFitness.Server.Api
{
    using System;
    using System.Data.Entity;
    using System.Web;

    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    using Data.Common.Repositories;
    using Data;
    using Common.Constants;
    using MyFitness.Common.Constants;
    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
           kernel.Bind(typeof(IRepository<>)).To(typeof(DeletableEntityRepository<>));
           kernel.Bind<DbContext>().To<MyFitnessDbContext>().InRequestScope();
     
           kernel.Bind(k => k
               .From(Assemblies.MyFitnessServices)
               .SelectAllClasses()
               .BindDefaultInterface());
        }
    }
}