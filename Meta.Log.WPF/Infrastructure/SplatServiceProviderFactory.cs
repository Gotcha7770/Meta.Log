using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Meta.Log.WPF.Infrastructure
{
    internal class SplatServiceProviderFactory : IServiceProviderFactory<IDependencyResolver>
    {
        public IDependencyResolver CreateBuilder(IServiceCollection services)
        {
            var resolver = Locator.GetLocator();
            Register(resolver, services);
            //resolver.InitializeSplat();
            resolver.InitializeReactiveUI();

            return resolver;
        }

        public IServiceProvider CreateServiceProvider(IDependencyResolver resolver)
        {
            return new SplatServiceProvider(resolver);
        }

        private static void Register(IDependencyResolver resolver, IEnumerable<ServiceDescriptor> descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                if (descriptor.ImplementationType != null)
                {
                //    // Test if the an open generic type is being registered
                //    var serviceTypeInfo = descriptor.ServiceType.GetTypeInfo();
                //    if (serviceTypeInfo.IsGenericTypeDefinition)
                //    {
                //        builder
                //            .RegisterGeneric(descriptor.ImplementationType)
                //            .As(descriptor.ServiceType)
                //            .ConfigureLifecycle(descriptor.Lifetime, lifetimeScopeTagForSingletons);
                //    }
                //    else
                //    {
                //        builder
                //            .RegisterType(descriptor.ImplementationType)
                //            .As(descriptor.ServiceType)
                //            .ConfigureLifecycle(descriptor.Lifetime, lifetimeScopeTagForSingletons);
                //    }
                }
                else if (descriptor.ImplementationFactory != null)
                {
                    var serviceProvider = resolver.GetService<IServiceProvider>();
                    resolver.Register(() => descriptor.ImplementationFactory(serviceProvider), descriptor.ServiceType);
                //    var registration = RegistrationBuilder.ForDelegate(descriptor.ServiceType, (context, parameters) =>
                //    {
                //        var serviceProvider = context.Resolve<IServiceProvider>();
                //        return descriptor.ImplementationFactory(serviceProvider);
                //    })
                //        .ConfigureLifecycle(descriptor.Lifetime, lifetimeScopeTagForSingletons)
                //        .CreateRegistration();

                //    builder.RegisterComponent(registration);
                }
                else
                {
                    resolver.RegisterConstant(descriptor.ImplementationInstance, descriptor.ServiceType);
                    //resolver.Register(() => descriptor.ImplementationInstance, descriptor.ServiceType);
                //    builder
                //        .RegisterInstance(descriptor.ImplementationInstance)
                //        .As(descriptor.ServiceType)
                //        .ConfigureLifecycle(descriptor.Lifetime, null);
                }
            }
        }

        internal class SplatServiceProvider : IServiceProvider
        {
            private IDependencyResolver _resolver;

            public SplatServiceProvider(IDependencyResolver resolver)
            {
                _resolver = resolver;
            }

            public object GetService(Type serviceType) => _resolver.GetService(serviceType);
        }
    }
}
