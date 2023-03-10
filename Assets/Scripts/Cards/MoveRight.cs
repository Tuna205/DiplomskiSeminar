using UnityEngine;

namespace Cards
{
    public class MoveRight : BaseCard
    {
        public override int Id => 1;

        public override bool Ability()
        {
            return _character.MoveToTile(_character.CurrentTile.Position + new Vector2Int(0, 1));
        }
    }
}