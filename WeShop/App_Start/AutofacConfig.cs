using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace WeShop.App_Start
{
    public class AutofacConfig
    {
        public static void autoDepence()
        {
            //1:先实例化一个构造器
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();//使用方

            var iRepository = Assembly.Load("Shop.IRepository");
            var iService = Assembly.Load("Shop.IService");

            var repository = Assembly.Load("Shop.Repository");
            var service = Assembly.Load("Shop.Service");

            builder.RegisterAssemblyTypes(iRepository, repository).Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(iService, service).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();//实现方

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}