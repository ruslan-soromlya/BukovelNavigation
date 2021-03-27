using System;
using System.Configuration;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BN.Logic.Interfaces;
using BN.UI.Console.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BN.UI.Console.App.Configuration
{
    public static class DiConfiguration
    {
        public static IServiceProvider Configure()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddLogging(l => l.AddConsole())
                .Configure<LoggerFilterOptions>(c => c.MinLevel = LogLevel.Trace);


            var builder = new ContainerBuilder();

            builder.Populate(serviceCollection);
            builder.RegisterInstance<IResortInfrastructureProvider>(
                new FromFileResortInfoProvider(ConfigurationManager.AppSettings.Get("ResortInfoFilePath")));
            builder.RegisterType<AppInstance>().SingleInstance();

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}