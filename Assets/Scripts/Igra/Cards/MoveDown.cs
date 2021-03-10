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
        private void OnValidate()
        {
            base.Init();
        }
        public override bool Ability()
        {
            return character.MoveToTile(character.position.tile.Position + new Vector2Int(1, 0));
        }
    }
}