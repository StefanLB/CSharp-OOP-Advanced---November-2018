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

    public string AnalyzeAcessModifiers(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);
        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo field in classFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (MethodInfo method in classPublicMethods.Where(m=>m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string investigatedClass)
    {
        Type type = Type.GetType(investigatedClass);

        MethodInfo[] classMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {investigatedClass}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (MethodInfo method in classMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }
}
