using UnityEngine;

namespace Cards
{
    public class PBlast : BaseAttackCard
    {
        public override int Id => 11;

        public override bool Ability()
        {
            DmgTile(_character.CurrentTile.Position + new Vector2Int(1, 0));
            DmgTile(_character.CurrentTile.Position + new Vector2Int(-1, 0));
            DmgTile(_character.CurrentTile.Position + new Vector2Int(0, 1));
            DmgTile(_character.CurrentTile.Position + new Vector2Int(0, -1));
            return true;
        }
    }
}