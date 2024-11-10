namespace GameItem
{
    public class BattleStatSubtractor : IStatModifier
    {
        private BattleStatData subtractStatData;

        public BattleStatSubtractor(BattleStatData subtractStatData)
        {
            this.subtractStatData = subtractStatData;
        }

        BattleStatData IStatModifier.Modify(BattleStatData origin)
        {
            return origin - subtractStatData;
        }
    }
}