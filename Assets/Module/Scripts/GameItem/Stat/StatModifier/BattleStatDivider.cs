namespace GameItem
{
    public class BattleStatDivider : IStatModifier
    {
        private BattleStatData dividerStatData;

        public BattleStatDivider(BattleStatData dividerStatData)
        {
            this.dividerStatData = dividerStatData;
        }

        BattleStatData IStatModifier.Modify(BattleStatData origin)
        {
            return origin / dividerStatData;
        }
    }
}