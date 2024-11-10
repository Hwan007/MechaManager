namespace GameItem
{
    public interface IStatHandler<TStatData> where TStatData : struct
    {
        public TStatData RecalculateStat();
        public TStatData ModifyStat(TStatData data);
    }
}
