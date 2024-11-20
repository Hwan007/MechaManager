using System;


namespace GameItem
{
    public class StatModule<TStatData> : Module<IStatHandler<TStatData>>, IStatHandler<TStatData> where TStatData : struct
    {
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
