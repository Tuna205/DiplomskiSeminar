using UnityEngine;

namespace Scripts.Cards
{
    class MoveUp : BaseCard
    {
        public override int Id
        {
            get
            {
                return 2;
            }
        }

        public override bool Ability()
        {
            return character.MoveToTile(character.CurrentTile.Position + new Vector2Int(-1, 0));
        }
    }
}