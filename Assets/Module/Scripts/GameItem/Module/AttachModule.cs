using System;
using System.Collections.Generic;


namespace GameItem
{
    public class AttachModule : IModule<IAttachHandler>, IAttachHandler
    {
        private LinkedList<BaseItem> attachItems = new LinkedList<BaseItem>();

        EAttachType IAttachHandler.GetAttachType(int index)
        {
            throw new NotImplementedException();
        }

        IModule IModule.Initailize()
        {
            throw new System.NotImplementedException();
        }

        bool IAttachHandler.TryAttachItem(int index, BaseItem item)
        {
            throw new NotImplementedException();
        }

        bool IAttachHandler.TryDettachItem(int index)
        {
            throw new NotImplementedException();
        }

        bool IAttachHandler.TryGetItem(int index, out BaseItem item)
        {
            throw new NotImplementedException();
        }

        bool IAttachHandler.TryGetItem<T>(int index, out T item)
        {
            throw new NotImplementedException();
        }

        bool IAttachHandler.TryGetItems(out BaseItem[] items)
        {
            throw new NotImplementedException();
        }

        bool IAttachHandler.TryGetItems<T>(out T[] items)
        {
            throw new NotImplementedException();
        }
    }
}
