using _03BarracksFactory.Contracts;
using _03BarraksWars.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace _03BarraksWars.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;
        private CommandFactory factory;

        public CommandInterpreter(IServiceProvider service)
        {
            this.serviceProvider = service;
            this.factory = new CommandFactory();
        }

        public IExecutable InterpretCommand(string[] data)
        {
            return factory.CreateCommand(data,this.serviceProvider);
        }
    }
}
