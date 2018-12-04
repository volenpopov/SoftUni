
using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
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

