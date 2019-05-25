namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            string[] commandArgs = inputParameters.Skip(1).ToArray();

            Type type = tankManager.GetType();
            MethodInfo[] publicMethods = type.GetMethods();

            MethodInfo selectedMethod =
            type.GetMethod(command);

            if (selectedMethod == null)
            {
                selectedMethod = type.GetMethod("Add" + command);
            }

            string result = (string)selectedMethod.Invoke(tankManager, new object[] { commandArgs });

            return result;
        }
    }
}