using System;

namespace Manager
{
    public class DataManager
    {
        Data runtimeData;

        public DataManager(Data runtimeData)
        {
            this.runtimeData = runtimeData;
        }

        public class Data
        {

        }
    }


    public interface IInitializable
    {
        void Initialize(DataManager.Data dataManager);
    }
}