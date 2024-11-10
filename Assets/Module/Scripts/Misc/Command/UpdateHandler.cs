using System.Collections.Generic;

namespace Command
{
    public class UpdateHandler : IUpdatable
    {
        private Queue<IUpdate> commandQueue;
        IUpdate currentCommand;
        IEnumerator<IUpdate> currentWork;

        void IUpdatable.Update()
        {
            if (ReferenceEquals(currentWork, null))
            {
                if (commandQueue.TryDequeue(out currentCommand))
                    currentWork = currentCommand.Execute();
            }
            else
            {
                bool isWorking = currentWork.MoveNext();
                if (!isWorking)
                    currentWork = null;
            }
        }

        public void PushCommand(params IUpdate[] commands)
        {
            foreach (var com in commands)
            {
                commandQueue.Enqueue(com);
            }
        }

        public void InterruptCommand(params IUpdate[] commands)
        {
            commandQueue.Clear();
            this.PushCommand(commands);
        }
    }

    public interface IUpdatable
    {
        public void Update();
    }

    public interface IUpdate
    {
        public IEnumerator<IUpdate> Execute();
    }
}

