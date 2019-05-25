namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);

            MethodInfo[] allMethods = type.GetMethods(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Static);

            var blackBoxInstance = (BlackBoxInteger)Activator.CreateInstance(type,true);

            string input = string.Empty;

            while ((input = Console.ReadLine())!="END")
            {
                string command = input.Split('_')[0];
                int numberProvided = int.Parse(input.Split('_')[1]);

                MethodInfo methodToExecute = allMethods.FirstOrDefault(m => m.Name == command);

                if (methodToExecute==null)
                {
                    continue;
                }

                methodToExecute.Invoke(blackBoxInstance, new object[] { numberProvided });

                var instanceInnerValue = type
                    .GetFields(BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Instance|BindingFlags.Static)
                    .FirstOrDefault(f=>f.Name=="innerValue")
                    .GetValue(blackBoxInstance);

                Console.WriteLine(instanceInnerValue);
            }
        }
    }
}
