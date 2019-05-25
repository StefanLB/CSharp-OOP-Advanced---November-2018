using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
        foreach (var method in methods)
        {
            var attributes = method.GetCustomAttributes<SoftUniAttribute>();

            foreach (SoftUniAttribute attr in attributes)
            {
                Console.WriteLine($"{method.Name} is written by {attr.Name}");
            }
        }

    }
}
