namespace GameItem
{
    public interface IAttachHandler
    {
        public bool TryGetItem(int index, out BaseItem item);
        public bool TryGetItem<T>(int index, out T item);
        public bool TryGetItems(out BaseItem[] items);
        public bool TryGetItems<T>(out T[] items);
        public bool TryAttachItem(int index, BaseItem item);
        public bool TryDettachItem(int index);
        public EAttachType GetAttachType(int index);
    }
}
