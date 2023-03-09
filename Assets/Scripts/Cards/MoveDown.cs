using UnityEngine;

namespace Cards
{
    public class MoveDown : BaseCard
    {
        public override int Id => 3;

        public override bool Ability()
        {
            return character.MoveToTile(character.CurrentTile.Position + new Vector2Int(1, 0));
        }
    }
}