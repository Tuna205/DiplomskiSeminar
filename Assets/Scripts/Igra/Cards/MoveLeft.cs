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
        private void OnValidate()
        {
            base.Init();
        }
        public override bool Ability()
        {
            return character.MoveToTile(character.position.tile.Position + new Vector2Int(0, -1));
        }
    }
}