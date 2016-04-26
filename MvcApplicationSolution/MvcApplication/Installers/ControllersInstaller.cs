using System;
using System.Web.Mvc;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MvcApplication.Facilities;
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
                    Component.For<EnumComponentSelector>()
                    .ImplementedBy<EnumComponentSelector>()
                    .LifestyleTransient());

            container.Register(
                    Component.For<IViewModelBuilder<DataViewModel, int>>()
                    .ImplementedBy<DataViewModelBuilder>()
                    .LifestyleTransient());

            container.Register(
                Component.For<IViewModelFactory>().AsFactory(x => x.SelectedWith<EnumComponentSelector>()));

            container.Register(
                Classes.FromAssemblyInThisApplication()
                .BasedOn<IViewModel>()
                .LifestyleTransient()
                .Configure(component => component.Named(GetComponentName(component.Implementation.Name))));

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }

        private static string GetComponentName(string name)
        {
            ViewModelType viewModelType;
            var vmName = name.Replace("ViewModel", "");

            if (Enum.TryParse(vmName, out viewModelType))
            {
                return viewModelType.ToString();
            }
            return Guid.NewGuid().ToString();
        }
    }
}