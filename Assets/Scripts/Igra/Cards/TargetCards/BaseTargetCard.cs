using Scripts.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Cards
{
    //TODO nes za slusanje eventova od tileova
    public abstract class BaseTargetCard : BaseAttackCard
    {
        protected abstract void ShowPlayableSquares();
        //MORA setat selectedtile 
        protected abstract void SetSelectedTile();
        protected abstract bool Ability(Vector2Int selectedRelative);

        //TODO mozda se moglo s listom selected tiles u Tile skripti
        protected List<Tile> canSelectTiles;

        protected Tile selectedTile;

        public override void Awake()
        {
            base.Awake();
            canSelectTiles = new List<Tile>();
        }

        //protected Vector2Int selectedTileRelative;
        public override void OnMouseDown()
        {
            if (hand.CanPlayCards == false) return;
            gameManager.CardQueue.Add(this);
            // na kraju korutine se unisti karta
            //StartCorutine(WaitForPlayerSelect());
        }

        private IEnumerator WaitForPlayerSelect()
        {
            ShowPlayableSquares();
            //check if player selected one of them
            /* bez WaitUntil
            int i = 0;
            while(i < 10000){
                i++;
                if(tileSelected == true){
                    selectedTile = SelectedTile();
                    break;
                }
                yield return null;
            }
            */
            yield return new WaitUntil(() => selectedTile != null);
            Vector2Int selectedTileRelative = selectedTile.Position - character.CurrentTile.Position;
            Ability(selectedTileRelative);

            hand.RemoveCard(this);
            hand.PlayedCard = true;
            UnmarkTilesSelected();
        }

        protected void MarkTilesSelectable(Vector2Int pos)
        {
            Tile tile = PosToTile(pos);
            if (tile == null) return;

            ChangeColor(tile, Color.green);
            canSelectTiles.Add(tile);
            tile.CanBeSelected = true;
        }

        protected void UnmarkTilesSelected()
        {
            foreach (Tile t in canSelectTiles)
            {
                t.CanBeSelected = false;
            }
            canSelectTiles.Clear();
        }

    }
}