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

        private void OnValidate()
        {
            base.Init();
        }
        public override bool Ability()
        {
            return character.MoveToTile(character.CurrentTile.Position + new Vector2Int(0, 1));
        }
    }
}