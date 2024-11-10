using System;


namespace GameItem
{
    public class StatModule<TStatData> : IModule<IStatHandler<TStatData>>, IStatHandler<TStatData> where TStatData : struct
    {
        IModule IModule.Initailize()
        {
            throw new System.NotImplementedException();
        }

        TStatData IStatHandler<TStatData>.ModifyStat(TStatData data)
        {
            throw new NotImplementedException();
        }

        TStatData IStatHandler<TStatData>.RecalculateStat()
        {
            throw new NotImplementedException();
        }
    }
}
