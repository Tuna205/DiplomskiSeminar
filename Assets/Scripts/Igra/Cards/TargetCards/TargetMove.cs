using Scripts.Map;
using UnityEngine;

namespace Scripts.Cards
{
    public class TargetMove : BaseTargetCard
    {
        public override int Id
        {
            get
            {
                return 21;
            }
        }

        public override bool Ability()
        {
            throw new System.NotImplementedException();
        }

        protected override bool Ability(Vector2Int selectedRelative)
        {
            character.MoveToTile(character.position.tile.Position + selectedRelative);
            return true;
        }

        protected override void SetSelectedTile()
        {
            //selectedTile = 
        }
        //TODO makni new
        protected override void ShowPlayableSquares()
        {
            MarkTilesSelectable(character.position.tile.Position + new Vector2Int(1, 1));
            MarkTilesSelectable(character.position.tile.Position + new Vector2Int(1, -1));
            MarkTilesSelectable(character.position.tile.Position + new Vector2Int(-1, 1));
            MarkTilesSelectable(character.position.tile.Position + new Vector2Int(-1, -1));

            MarkTilesSelectable(character.position.tile.Position + new Vector2Int(1, 0));
            MarkTilesSelectable(character.position.tile.Position + new Vector2Int(-1, 0));
            MarkTilesSelectable(character.position.tile.Position + new Vector2Int(0, 1));
            MarkTilesSelectable(character.position.tile.Position + new Vector2Int(0, -1));
        }
    }
}