using UnityEngine;

namespace Cards
{
    public class MoveRight : BaseCard
    {
        public override int Id => 1;

        public override bool Ability()
        {
            return character.MoveToTile(character.CurrentTile.Position + new Vector2Int(0, 1));
        }
    }
}