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
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<CourseService>().As<ICourseService>();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>();


            return builder.Build();
        }



    }
}