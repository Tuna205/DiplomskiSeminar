using UnityEngine;

namespace Scripts.Cards
{
    class MoveDown : BaseCard
    {
        public override int Id
        {
            get
            {
                return 3;
            }
        }

        public override bool Ability()
        {
            return character.MoveToTile(character.CurrentTile.Position + new Vector2Int(1, 0));
        }
    }
}