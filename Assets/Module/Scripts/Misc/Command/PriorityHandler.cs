using System;
using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class PriorityHandler : IPriorityHandler
    {
        private LinkedList<IPriority> executedCommand;
        private List<Queue<IPriority>> commandQueue;

        public PriorityHandler()
        {
            executedCommand = new LinkedList<IPriority>();
            commandQueue = new List<Queue<IPriority>>();
            int length = Enum.GetValues(typeof(EPriority)).Length;
            for (; length > 0; --length)
            {
                commandQueue.Add(new Queue<IPriority>());
            }
        }

        void IPriorityHandler.TryExecuteCommand()
        {
            for (int i = 0; i < commandQueue.Count; ++i)
            {
                if (commandQueue[i].TryDequeue(out var command))
                {
                    command.Execute();
                    executedCommand.AddLast(command);
                    return;
                }
            }
        }

        public void PushCommand(IPriority command, EPriority priority = EPriority.Normal)
        {
            Debug.Assert(priority >= 0, $"{nameof(EPriority)} must bigger or same than 0.");
            commandQueue[(int)priority].Enqueue(command);
        }

        void IPriorityHandler.InterruptCommand(IPriority command)
        {
            commandQueue[0].Clear();
            commandQueue[0].Enqueue(command);
        }

        public void ClearQueue()
        {
            for (int i = 0; i < commandQueue.Count; ++i)
            {
                commandQueue[i].Clear();
            }
        }

        public void ClearExecuted()
        {
            executedCommand.Clear();
        }
    }

    public enum EPriority
    {
        immediately = 0,
        Fast,
        Normal,
    }

    public interface IPriority
    {
        public void Execute();
    }

    public interface IPriorityHandler
    {
        public void TryExecuteCommand();
        public void PushCommand(IPriority command, EPriority priority = EPriority.Normal);
        public void InterruptCommand(IPriority command);
    }
}

