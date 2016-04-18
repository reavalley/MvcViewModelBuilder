using System.Web.Mvc;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MvcApplication.Models;

namespace MvcApplication.Installers
{
    using Plumbing;
    using Services;
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<IController>().
                    If(c => c.Name.EndsWith("Controller")).
                    LifestyleTransient());

            container.Register(
                    Component.For<ITestService>()
                    .ImplementedBy<TestService>()
                    .LifestyleTransient());

            container.Register(
                    Component.For<IViewModelBuilder>()
                    .ImplementedBy<ViewModelBuilder>()
                    .LifestyleTransient());

            container.Register(
                Component.For<IViewModelFactory>().AsFactory());

            container.Register(
                Classes.FromAssemblyInThisApplication()
                .BasedOn<IViewModel>()
                .LifestyleTransient());

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }
    }
}