using UnityEngine;

namespace Cards
{
    public class MoveUp : BaseCard
    {
        public override int Id => 2;

        public override bool Ability()
        {
            return _character.MoveToTile(_character.CurrentTile.Position + new Vector2Int(-1, 0));
        }
    }
}