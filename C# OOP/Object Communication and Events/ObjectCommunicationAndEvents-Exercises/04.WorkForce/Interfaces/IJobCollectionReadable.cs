using System.Collections.Generic;

namespace _04.WorkForce.Interfaces
{
    public interface IJobCollectionReadable
    {
        IReadOnlyCollection<IJob> JobList { get; }
    }
}
