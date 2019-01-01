namespace _04.WorkForce.Interfaces
{
    public delegate void JobDoneEventHandler(IJob job);

    public interface IJob : INameable, IWorkable
    {
        event JobDoneEventHandler JobDoneEvent;

        int HoursOfWorkRequired { get; }

        void Update();
    }
}
