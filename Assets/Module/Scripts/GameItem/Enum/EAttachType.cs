using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameItem
{
    public enum EAttachType
    {
        None,
        Mechanical,
        Magical,
    }

    public struct AttachTypeLayer
    {
        private readonly uint capacity;
        private uint[] value;

        public AttachTypeLayer(params EAttachType[] types)
        {
            capacity = 0;
            foreach (var type in types)
            {
                int targetValue = (int)type;
                uint length = (uint)(targetValue / 8 + 1);
                if (length > capacity)
                {
                    capacity = length;
                }
            }
            value = new uint[capacity];
            foreach (var type in types)
            {
                uint targetValue = (uint)type;
                uint index = targetValue / 8;
                value[index] += (uint)(1 << ((int)targetValue % 8));
            }
        }

        public EAttachType[] GetAttachType()
        {
            List<EAttachType> result = new List<EAttachType>(capacity * 8);
            foreach (var valueFlagment in value)
            {
                int temp = valueFlagment;
                int count = 0;
                int limit = sizeof(int) * 8;
                for (int i = 0; i < limit; ++i)
                {
                    if ((temp & 1) == 1)
                    {
                        ++count;
                        result.Add((EAttachType)i);
                    }
                    temp >>= 1;
                }
            }
            return result.ToArray();
        }

        public bool IsContain(EAttachType type)
        {
            if ((value & (1 << (int)type)) != 0)
                return true;
            return false;
        }
    }

}
