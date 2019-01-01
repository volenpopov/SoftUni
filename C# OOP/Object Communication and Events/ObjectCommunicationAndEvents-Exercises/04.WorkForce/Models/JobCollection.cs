using _04.WorkForce.Interfaces;
using System;
using System.Collections.Generic;

namespace _04.WorkForce.Models
{
    public class JobCollection : IJobCollectionReadable
    {
        private IList<IJob> jobs;

        public JobCollection()
        {
            this.jobs = new List<IJob>();
        }

        public IReadOnlyCollection<IJob> JobList => 
                (IReadOnlyCollection<IJob>)this.jobs;

        public void AddJob(IJob job)
        {
            this.jobs.Add(job);
            job.JobDoneEvent += this.OnJobDone;
        }

        private void OnJobDone(IJob job)
        {
            Console.WriteLine($"{job.GetType().Name} {job.Name} done!");

            this.jobs.Remove(job);
        }
    }
}
