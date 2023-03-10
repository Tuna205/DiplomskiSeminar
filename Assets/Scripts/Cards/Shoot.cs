using UnityEngine;

namespace Cards
{
    public class Shoot : BaseAttackCard
    {
        public override int Id => 13;
        
        public override bool Ability()
        {
            DmgTile(_character.CurrentTile.Position + new Vector2Int(1, 0));
            DmgTile(_character.CurrentTile.Position + new Vector2Int(-1, 0));
            DmgTile(_character.CurrentTile.Position + new Vector2Int(0, 1));
            DmgTile(_character.CurrentTile.Position + new Vector2Int(0, -1));

            DmgTile(_character.CurrentTile.Position + new Vector2Int(2, 0));
            DmgTile(_character.CurrentTile.Position + new Vector2Int(-2, 0));
            DmgTile(_character.CurrentTile.Position + new Vector2Int(0, 2));
            DmgTile(_character.CurrentTile.Position + new Vector2Int(0, -2));
            return true;
        }
    }
}