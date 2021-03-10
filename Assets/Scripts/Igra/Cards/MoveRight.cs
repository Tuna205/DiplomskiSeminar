using UnityEngine;

namespace Scripts.Cards
{
    class MoveRight : BaseCard
    {
        public override int Id
        {
            get
            {
                return 1;
            }
        }

        public override bool Ability()
        {
            return character.MoveToTile(character.CurrentTile.Position + new Vector2Int(0, 1));
        }
    }
}