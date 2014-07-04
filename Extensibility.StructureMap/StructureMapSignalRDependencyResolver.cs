using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Extensibility.BasicDI
{
    public class StructureMapSignalRDependencyResolver : DefaultDependencyResolver
    {
        private StructureMap.Container _container;

        public StructureMapSignalRDependencyResolver(StructureMap.Container container)
        {
            _container = container;
        }

        public override object GetService(Type serviceType)
        {
            object service = null;

            if (!serviceType.IsAbstract && !serviceType.IsInterface && serviceType.IsClass)
            {
                service = _container.GetInstance(serviceType);
            }
            else
            {
                service = _container.TryGetInstance(serviceType) ?? base.GetService(serviceType);
            }

            return service;
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            IEnumerable<object> allInstances = _container.GetAllInstances(serviceType).Cast<object>().Concat(base.GetServices(serviceType));
            return allInstances;
        }
    }
}