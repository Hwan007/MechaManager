namespace GameItem
{
    public class BattleStatMultiplier : IStatModifier
    {
        private BattleStatData multiplierStatData;

        public BattleStatMultiplier(BattleStatData multiplierStatData)
        {
            this.multiplierStatData = multiplierStatData;
        }

        BattleStatData IStatModifier.Modify(BattleStatData origin)
        {
            return origin * multiplierStatData;
        }
    }
}