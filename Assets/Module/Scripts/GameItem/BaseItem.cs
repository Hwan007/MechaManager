using System.Collections.Generic;

namespace GameItem
{
    public interface IModuleHandler
    {
        public bool TryGetModule<TModule>(out TModule module) where TModule : class, IModule;
        public bool TryAddModule<TModule>(TModule module) where TModule : class, IModule;
    }

    public abstract class BaseItem : IModuleHandler
    {
        private string id;
        private LinkedList<IModule> modules = new LinkedList<IModule>();

        public bool TryGetModule<TModule>(out TModule module) where TModule : class, IModule
        {
            var mo = modules.First;
            while (ReferenceEquals(mo, null))
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

        public bool TryAddModule<TModule>(TModule module) where TModule : class, IModule
        {
            if (TryGetModule<TModule>(out _))
            {
                return false;
            }
            else
            {
                modules.AddLast(module);
                return true;
            }
        }
    }
}
