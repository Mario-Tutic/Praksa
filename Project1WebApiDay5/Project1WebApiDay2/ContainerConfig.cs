using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University.Model;
using University.Model.Common;
using Student.Service.Common;
using Student.Service;
using Student.Repository.Common;
using Student.Repository;
namespace Project1WebApiDay2
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Course>().As<ICourse>();
            builder.RegisterType<StudentInfo>().As<IStudentInfo>();
            builder.RegisterType<CourseService>().As<ICourseService>();
            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>();
            return builder.Build();

        }
    }
}