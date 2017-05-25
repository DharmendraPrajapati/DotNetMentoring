using System.Data.Entity;
using System.Web.Mvc;
using BusinessLogicLayer;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataAccessLayer;
using DataAccessLayer.Repositories.CourseRepositories;
using DataAccessLayer.Repositories.GenericRepositories;
using DataAccessLayer.UnitOfWork;
using SchoolWebUI.Controllers;

namespace SchoolWebUI.DIInstaller
{
    public class DaoRepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
          
            container.Register(Component.For<DbContext>().ImplementedBy<SchoolEntitiesContext>());
            container.Register(Component.For<ICourseRepository>().ImplementedBy<CourseRepository>());
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>());
            container.Register(Component.For<BlCourseRepository>().ImplementedBy<BlCourseRepository>());
            //BLCourseRepository



        }
    }
}