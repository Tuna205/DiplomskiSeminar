using UnityEngine;

namespace Cards
{
    public class XBlast : BaseAttackCard
    {
        public override int Id => 12;

        public override bool Ability()
        {
            DmgTile(character.CurrentTile.Position + new Vector2Int(1, 1));
            DmgTile(character.CurrentTile.Position + new Vector2Int(1, -1));
            DmgTile(character.CurrentTile.Position + new Vector2Int(-1, 1));
            DmgTile(character.CurrentTile.Position + new Vector2Int(-1, -1));
            return true;
        }
    }
}