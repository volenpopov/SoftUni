using System.Text;

public class Engineer : Private, IEngineer, ICorps
{
    public override string ToString()
    {
        return $"{base.ToString()}\n" +
            $"Corps: {Corp}\n" +
            $"Repairs:{PrintRepairs()}".TrimEnd();            
    }

    public Engineer(string id, string firstName, string lastName, double salary, string corp)
        : base(id, firstName, lastName, salary)
    {
        Corp = corp;
    }

    private string PrintRepairs()
    {
        StringBuilder sb = new StringBuilder();

        if (Repairs.Length >= 1)
        {
            sb.AppendLine();

            for (int i = 0; i < Repairs.Length - 1; i += 2)
            {
                sb.AppendLine($"    Part Name: {Repairs[i]} Hours Worked: {Repairs[i + 1]}");
            }

            return sb.ToString().TrimEnd();
        }
        else
            return string.Empty;
        
    }

    public void GetRepairs(string[] elements)
    {
        Repairs = new string[elements.Length - 6];
        int k = 0;
        for (int i = 6; i < elements.Length; i++, k++)
        {
            Repairs[k] = elements[i];
        }
    }

    public string[] Repairs { get; set; }
    public string Corp { get; set; }


}