using System;
using System.Collections.Generic;
using System.Linq;


namespace GameItem
{
    public struct AttachData
    {
        public AttachTypeLayer typeLayers;
        public int capacity;
    }

    public struct SlotData
    {
        public int id;
        public AttachData attachData;

        public SlotData(int id, AttachData attachData)
        {
            this.id = id;
            this.attachData = attachData;
        }
    }

    public struct AttachSlotData
    {
        public SlotData slotData;
        public bool IsAttached => !ReferenceEquals(item, null);
        public EAttachType type;
        public BaseItem item;
        public int ID => slotData.id;
        public AttachSlotData(int id, AttachData attachData)
        {
            slotData = new SlotData(id, attachData);
            type = EAttachType.None;
            item = null;
        }
    }
    public class AttachModule : Module<IAttachHandler>, IAttachHandler
    {
        private LinkedList<AttachSlotData> slots;

        public AttachModule(params AttachData[] datas)
        {
            int id = 0;
            slots = new LinkedList<AttachSlotData>();
            foreach (var data in datas)
            {
                slots.AddLast(new AttachSlotData(++id, data));
            }
        }

        SlotData[] IAttachHandler.GetAvaliableSlot()
        {
            var result = slots.Where(item => item.IsAttached).Select(item => item.slotData).ToArray<SlotData>();
            return result;
        }

        bool IAttachHandler.TryAttachItem(int id, BaseItem item)
        {
            throw new NotImplementedException();
        }

        bool IAttachHandler.TryDettachItem(BaseItem item)
        {
            throw new NotImplementedException();
        }

        bool IAttachHandler.TryDettachItem(int id, out BaseItem item)
        {
            throw new NotImplementedException();
        }

        bool IAttachHandler.TryGetItem(int id, out BaseItem item)
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
