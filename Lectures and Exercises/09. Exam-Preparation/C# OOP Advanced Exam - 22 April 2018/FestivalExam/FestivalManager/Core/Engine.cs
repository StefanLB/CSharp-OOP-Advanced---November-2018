
namespace FestivalManager.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalController;
        private ISetController setController;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalController, ISetController setController)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalController = festivalController;
            this.setController = setController;
        }

        public void Run()
        {
            string input = string.Empty;

            while (input != "END")
            {

                input = reader.ReadLine();

                if (input == "END")
                {
                    continue;
                }

                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            string end = this.festivalController.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var tokens = input.Split();

            var command = tokens[0];
            var parameters = tokens.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                var sets = this.setController.PerformSets();
                return sets;
            }

            var festivalcontrolfunction = this.festivalController
                .GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

            string result;

            try
            {
                result = (string)festivalcontrolfunction
                .Invoke(this.festivalController, new object[] { parameters });
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
            return result;
        }
    }
}