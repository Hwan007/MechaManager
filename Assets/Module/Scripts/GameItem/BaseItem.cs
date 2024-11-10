using System.Collections.Generic;

namespace GameItem
{

    public interface IModule
    {
        public IModule Initailize();
    }

    public interface IModule<THandler> : IModule
    {

    }

    public abstract class BaseItem
    {
        private string id;
        private LinkedList<IModule> modules = new LinkedList<IModule>();

        public abstract void InitializeModule();

        public bool TryGetModule<TModule>(out TModule module) where TModule : class, IModule
        {
            var mo = modules.First;
            while(ReferenceEquals(mo, null))
            {
                if (mo.Value is TModule target)
                {
                    module = target;
                    return true;
                }
            }
            module = null;
            return false;
        }
    }

}
