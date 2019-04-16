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
        private void OnValidate()
        {
            base.Init();
        }
        public override bool Ability()
        {
            return player.MoveToTile(player.position.tile.Position + new Vector2Int(-1, 0));
        }
    }
}