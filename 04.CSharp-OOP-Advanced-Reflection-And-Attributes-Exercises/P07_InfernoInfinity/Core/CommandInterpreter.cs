using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P07_InfernoInfinity.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider provider)
        {
            this.serviceProvider = provider;
        }

        public IExecutable InterpretCommand(string[] data)
        {
            var commandType = data[0];
            data = data.Skip(1).ToArray();

            Assembly assembly = Assembly.GetExecutingAssembly();
            var model = assembly.GetTypes().FirstOrDefault(x => x.Name == commandType);

            if (model == null)
            {
                throw new ArgumentException("Invalid type!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(model))
            {
                throw new ArgumentException(model + " is not Weapon type!");
            }

            PropertyInfo[] propertiesToInject = model
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttributes<InjectAttribute>().Any()).ToArray();

            var injectProps = propertiesToInject
                .Select(p => serviceProvider.GetService(p.PropertyType))
                .ToArray();

            var joinedParams = new object[] { data }.Concat(injectProps).ToArray();

            IExecutable command = (IExecutable)Activator.CreateInstance(model, joinedParams);
            return command;
        }
    }
}
