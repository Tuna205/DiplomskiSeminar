using System.Collections;
using System.Collections.Generic;
using Maps;
using UnityEngine;

namespace Cards.TargetCards
{
    //TODO čemu služi tile can be selected???
    //TODO nes za slusanje eventova od tileova
    public abstract class BaseTargetCard : BaseAttackCard
    {
        protected abstract void ShowPlayableSquares();

        //MORA setat selectedtile 
        protected abstract void SetSelectedTile();
        protected abstract bool Ability(Vector2Int selectedRelative);

        //TODO mozda se moglo s listom selected tiles u Tile skripti
        private List<Tile> _canSelectTiles;

        private Tile _selectedTile;

        public override void Awake()
        {
            base.Awake();
            _canSelectTiles = new List<Tile>();
        }

        //protected Vector2Int selectedTileRelative;
        public override void OnMouseDown()
        {
            if (_hand.CanPlayCards == false) return;
            _gameManager.CardQueue.Add(this);
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
            yield return new WaitUntil(() => _selectedTile != null);
            Vector2Int selectedTileRelative = _selectedTile.Position - _character.CurrentTile.Position;
            Ability(selectedTileRelative);

            _hand.RemoveCard(this);
            _hand.onCardPlayed?.Invoke();
            UnMarkTilesSelected();
        }

        protected void MarkTilesSelectable(Vector2Int pos)
        {
            Tile tile = PosToTile(pos);
            if (tile == null) return;

            ChangeColor(tile, Color.green);
            _canSelectTiles.Add(tile);
            tile.CanBeSelected = true;
        }

        private void UnMarkTilesSelected()
        {
            foreach (Tile t in _canSelectTiles)
            {
                t.CanBeSelected = false;
            }

            _canSelectTiles.Clear();
        }
    }
}