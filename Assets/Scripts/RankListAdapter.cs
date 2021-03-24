using BadNorth.Scripts.UI.OSAExtend;
using Com.TheFallenGames.OSA.Core;

namespace Scripts.ArenaRank
{
    public class RankListAdapter : OSAListBase<BattleButton.PlayerDataInfo, RankListViewHolder>
    {
        protected override void SetViewsHolderData(RankListViewHolder viewsHolder, BattleButton.PlayerDataInfo model)
        {
            viewsHolder.cell.SetData(model);
        }
    }

    public class RankListViewHolder : BaseItemViewsHolder
    {
        public RankItem cell;

        public override void CollectViews()
        {
            base.CollectViews();
            cell = root.GetComponentInChildren<RankItem>();
        }
    }
}