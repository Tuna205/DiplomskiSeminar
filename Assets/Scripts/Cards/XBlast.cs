using UnityEngine;

namespace Cards
{
    public class XBlast : BaseAttackCard
    {
        public override int Id => 12;

        public override bool Ability()
        {
            DmgTile(_character.CurrentTile.Position + new Vector2Int(1, 1));
            DmgTile(_character.CurrentTile.Position + new Vector2Int(1, -1));
            DmgTile(_character.CurrentTile.Position + new Vector2Int(-1, 1));
            DmgTile(_character.CurrentTile.Position + new Vector2Int(-1, -1));
            return true;
        }
    }
}