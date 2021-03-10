using UnityEngine;

namespace Scripts.Cards
{
    class MoveLeft : BaseCard
    {
        public override int Id
        {
            get
            {
                return 4;
            }
        }

        public override bool Ability()
        {
            return character.MoveToTile(character.CurrentTile.Position + new Vector2Int(0, -1));
        }
    }
}