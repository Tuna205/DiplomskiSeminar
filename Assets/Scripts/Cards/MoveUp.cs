using UnityEngine;

namespace Cards
{
    public class MoveUp : BaseCard
    {
        public override int Id => 2;

        public override bool Ability()
        {
            return character.MoveToTile(character.CurrentTile.Position + new Vector2Int(-1, 0));
        }
    }
}