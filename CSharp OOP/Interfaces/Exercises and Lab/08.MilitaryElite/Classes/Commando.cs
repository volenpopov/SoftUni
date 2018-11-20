using System.Collections.Generic;
using System.Text;

public class Commando : Private, ICommando, ICorps
{
    public override string ToString()
    {
        return $"{base.ToString()}\n" +
            $"Corps: {Corp}\n" +
            $"  Missions:{PrintMissions()}".TrimEnd();           
    }

    private string PrintMissions()
    {
        StringBuilder sb = new StringBuilder();

        if (Missions.Count >= 1)
        {
            sb.AppendLine();

            for (int i = 0; i < Missions.Count - 1; i += 2)
            {
                sb.AppendLine($"Code Name: {Missions[i]} State: {Missions[i + 1]}");
            }

            return sb.ToString().TrimEnd();
        }
        else
            return string.Empty;
       
    }

    public void GetMissions(string[] elements)
    {
        for (int i = 6; i < elements.Length - 1; i += 2)
        {
            if (elements[i + 1] == "inProgress" || elements[i + 1] == "Finished")
            {
                Missions.Add(elements[i]);
                Missions.Add(elements[i + 1]);
            }
        }
    }

    public Commando(string id, string firstName, string lastName, double salary, string corp)
        : base(id, firstName, lastName, salary)
    {        
        Corp = corp;
        Missions = new List<string>();
    }

    public List<string> Missions { get; set; }
    public string Corp { get; set; }
}