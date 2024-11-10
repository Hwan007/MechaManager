namespace GameItem
{
    public class BattleStatAdder : IStatModifier
    {
        private BattleStatData addStatData;

        public BattleStatAdder(BattleStatData addStatData)
        {
            this.addStatData = addStatData;
        }

        BattleStatData IStatModifier.Modify(BattleStatData origin)
        {
            return origin + addStatData;
        }
    }
}
