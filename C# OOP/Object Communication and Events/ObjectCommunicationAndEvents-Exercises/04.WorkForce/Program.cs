using _04.WorkForce.Interfaces;
using _04.WorkForce.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.WorkForce
{
    class Program
    {
        static void Main()
        {
            JobCollection jobs = new JobCollection();
            List<IEmployee> employees = new List<IEmployee>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] args = input.Split();
                string command = args[0];
                
                switch (command)
                {
                    case "Job":
                        string jobName = args[1];
                        int hoursRequired = int.Parse(args[2]);
                        string employeeName = args[3];

                        IEmployee employee = employees.First(e => e.Name == employeeName);

                        IJob job = new Job(employee, jobName, hoursRequired);

                        jobs.AddJob(job);
                        break;

                    case "StandardEmployee":
                        employeeName = args[1];
                        employees.Add(new StandardEmployee(employeeName));
                        break;

                    case "PartTimeEmployee":
                        employeeName = args[1];
                        employees.Add(new PartTimeEmployee(employeeName));
                        break;

                    case "Status":
                        foreach (var j in jobs.JobList)
                        {
                            Console.WriteLine(j);
                        }
                        break;

                    case "Pass":
                        jobs.JobList.ToList().ForEach(j => j.Update());
                        break;
                }

            }
        }
    }
}
