using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] fieldsToInvestigate)
    {
        Type type = Type.GetType(investigatedClass);

        FieldInfo[] fieldsInfo = type.GetFields(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {investigatedClass}");

        var classInstance = Activator.CreateInstance(type, new object[] { });

        foreach (FieldInfo field in fieldsInfo.Where(f=>fieldsToInvestigate.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}
