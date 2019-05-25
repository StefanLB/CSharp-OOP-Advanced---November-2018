using Microsoft.Extensions.DependencyInjection;
using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Core;
using P07_InfernoInfinity.Core.Factories;
using P07_InfernoInfinity.Core.IO;
using P07_InfernoInfinity.Data;
using System;

namespace P07_InfernoInfinity
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            IRunnable engine = new Engine(commandInterpreter, writer, reader);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IWeaponFactory, WeaponFactory>();
            services.AddTransient<IGemFactory, GemFactory>();
            services.AddTransient<IWriter, ConsoleWriter>();
            services.AddSingleton<IRepository, WeaponRepository>();

            IServiceProvider provider = services.BuildServiceProvider();
            return provider;
        }
    }
}
