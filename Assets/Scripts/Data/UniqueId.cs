using System;

namespace Data
{
    [Serializable]
    public abstract class UniqueId
    {
        public string Id;
        public int TypeId;
    }
}