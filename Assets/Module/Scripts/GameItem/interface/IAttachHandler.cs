namespace GameItem
{
    public interface IAttachHandler
    {
        public bool TryGetItem(int id, out BaseItem item);
        public bool TryGetItems(out BaseItem[] items);
        public bool TryGetItems<T>(out T[] items);
        public bool TryAttachItem(int id, BaseItem item);
        public bool TryDettachItem(int id, out BaseItem item);
        public bool TryDettachItem(BaseItem item);
        public SlotData[] GetAvaliableSlot();
    }
}
