using UnityEngine;

namespace Cards
{
    public class MoveLeft : BaseCard
    {
        public override int Id => 4;

        public override bool Ability()
        {
            return _character.MoveToTile(_character.CurrentTile.Position + new Vector2Int(0, -1));
        }
    }
}