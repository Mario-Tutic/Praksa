using Autofac;
using Autofac.Integration.WebApi;
using Student.Service.Common;
using Student.Service;
using Student.Repository.Common;
using Student.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Project1WebApiDay2
{
    public static class ContainerConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterModule(new ServiceDIModule());
            builder.RegisterModule(new RepositoryDIModule());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            Container = builder.Build();
            return Container;
        }
    }
}