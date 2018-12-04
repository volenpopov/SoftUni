
using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string classToInvestigate)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(classToInvestigate);

        var classInstance = Activator.CreateInstance(classType);

        FieldInfo[] classFields = classType
            .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        MethodInfo[] classPublicMethods = classType
            .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

        MethodInfo[] classPrivateMethods = classType
            .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        foreach (var field in classFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var methodGetter in classPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{methodGetter.Name} have to be public!");
        }

        foreach (var methodSetter in classPrivateMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{methodSetter.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string classToInvestigate)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(classToInvestigate);

        sb.AppendLine($"All Private Methods of Class: {classToInvestigate}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        MethodInfo[] classPrivateMethods = classType
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var method in classPrivateMethods)
        {
            sb.AppendLine($"{method.Name}");
        }

        return sb.ToString().Trim();
    }

    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        Type classType = Type.GetType(classToInvestigate);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {classToInvestigate}");

        var classInstance = Activator.CreateInstance(classType);

        FieldInfo[] fields = Type.GetType(classToInvestigate).GetFields(BindingFlags.Public
            | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

        foreach (var field in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}

