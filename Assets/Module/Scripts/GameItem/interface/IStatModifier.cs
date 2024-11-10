namespace GameItem
{
    public interface IStatModifier
    {
        public BattleStatData Modify(BattleStatData origin);
    }
}