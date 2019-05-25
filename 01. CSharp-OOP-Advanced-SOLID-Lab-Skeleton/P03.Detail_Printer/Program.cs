using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            IList < Employee > employees = new List<Employee>();
            employees.Add(new Employee("Goshaka"));
            employees.Add(new Manager("Na Goshaka Shefa", new Collection<string> { "doc1", "doc2", "doc3", "topSecretDocNotVisibleToAnyone" }));
            employees.Add(new Employee("Na Goshaka kolegata"));
            employees.Add(new Manager("Mnogo vojd malko indianec", new Collection<string> { "doc4", "doc5", "doc6" }));

            DetailsPrinter dp = new DetailsPrinter(employees);

            dp.PrintDetails();
        }
    }
}
