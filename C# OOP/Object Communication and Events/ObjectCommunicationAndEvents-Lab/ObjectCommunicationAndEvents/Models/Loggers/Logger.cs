using System;

namespace ObjectCommunicationAndEvents
{
    public abstract class Logger : IHandler
    {
        private IHandler successor;

        public abstract void Handle(LogType logType, string message);

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        protected void PassToSuccessor(LogType logType, string message)
        {
            if (this.successor != null)
                this.successor.Handle(logType, message);
        }
    }
}
