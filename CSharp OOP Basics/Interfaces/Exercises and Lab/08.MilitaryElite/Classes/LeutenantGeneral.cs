
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public override string ToString()
    {
        return $"{base.ToString()}\n" +
            $"Privates:{PrintPrivates()}";
    }

    public void AppointPrivates(List<Private> privates, string[] elements, LeutenantGeneral leutenant)
    {
        if (elements.Length > 5)
        {
            for (int i = 5; i < elements.Length; i++)
            {
                var priv = privates.FirstOrDefault(p => p.Id == elements[i]);
                if (priv != null)
                    leutenant.Privates.Add(priv);
            }
        }
    }

    private string PrintPrivates()
    {
        StringBuilder sb = new StringBuilder();

        if (Privates.Count >= 1)
        {
            sb.AppendLine();
            for (int i = 0; i < Privates.Count; i++)
            {
                sb.AppendLine(Privates[i].ToString());
            }

            return sb.ToString().TrimEnd();
        }
        else
            return string.Empty;
    }

    public LeutenantGeneral(string id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName, salary)
    {
        Privates = new List<Private>();
    }

    public List<Private> Privates { get; set; }
}

