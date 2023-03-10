using UnityEngine;

namespace Cards.TargetCards
{
    public class TargetMove : BaseTargetCard
    {
        public override int Id => 21;

        public override bool Ability()
        {
            throw new System.NotImplementedException();
        }

        protected override bool Ability(Vector2Int selectedRelative)
        {
            _character.MoveToTile(_character.CurrentTile.Position + selectedRelative);
            return true;
        }

        protected override void SetSelectedTile()
        {
            //selectedTile = 
        }

        protected override void ShowPlayableSquares()
        {
            MarkTilesSelectable(_character.CurrentTile.Position + new Vector2Int(1, 1));
            MarkTilesSelectable(_character.CurrentTile.Position + new Vector2Int(1, -1));
            MarkTilesSelectable(_character.CurrentTile.Position + new Vector2Int(-1, 1));
            MarkTilesSelectable(_character.CurrentTile.Position + new Vector2Int(-1, -1));

            MarkTilesSelectable(_character.CurrentTile.Position + new Vector2Int(1, 0));
            MarkTilesSelectable(_character.CurrentTile.Position + new Vector2Int(-1, 0));
            MarkTilesSelectable(_character.CurrentTile.Position + new Vector2Int(0, 1));
            MarkTilesSelectable(_character.CurrentTile.Position + new Vector2Int(0, -1));
        }
    }
}