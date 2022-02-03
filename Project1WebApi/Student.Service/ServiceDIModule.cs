using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Student.Service.Common;

namespace Student.Service
{
    public class ServiceDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>()
                       .As<IStudentService>()
                       .InstancePerRequest();

            builder.RegisterType<CourseService>()
                       .As<ICourseService>()
                       .InstancePerRequest();
        }
    }
}
