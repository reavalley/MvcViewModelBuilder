using System;
using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using MvcApplication.Models;

namespace MvcApplication.Facilities
{
    public class NamedComponentFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.ComponentRegistered += Kernel_ComponentRegistered;
        }

        private void Kernel_ComponentRegistered(string key, IHandler handler)
        {
            if (typeof(IViewModel).IsAssignableFrom(handler.ComponentModel.Implementation))
            {
                ViewModelType viewModelType;

                var vmName = handler.ComponentModel.Implementation.Name.Replace("ViewModel", "");

                if (Enum.TryParse(vmName, out viewModelType))
                {
                    handler.ComponentModel.Name = viewModelType.ToString();
                }
            }
        }
    }
}