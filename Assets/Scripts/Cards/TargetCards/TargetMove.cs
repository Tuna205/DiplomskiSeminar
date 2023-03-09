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
            character.MoveToTile(character.CurrentTile.Position + selectedRelative);
            return true;
        }

        protected override void SetSelectedTile()
        {
            //selectedTile = 
        }

        protected override void ShowPlayableSquares()
        {
            MarkTilesSelectable(character.CurrentTile.Position + new Vector2Int(1, 1));
            MarkTilesSelectable(character.CurrentTile.Position + new Vector2Int(1, -1));
            MarkTilesSelectable(character.CurrentTile.Position + new Vector2Int(-1, 1));
            MarkTilesSelectable(character.CurrentTile.Position + new Vector2Int(-1, -1));

            MarkTilesSelectable(character.CurrentTile.Position + new Vector2Int(1, 0));
            MarkTilesSelectable(character.CurrentTile.Position + new Vector2Int(-1, 0));
            MarkTilesSelectable(character.CurrentTile.Position + new Vector2Int(0, 1));
            MarkTilesSelectable(character.CurrentTile.Position + new Vector2Int(0, -1));
        }
    }
}