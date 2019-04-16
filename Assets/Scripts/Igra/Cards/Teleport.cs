
using System.Collections;
using UnityEngine;

namespace Scripts.Cards
{

    public class Teleport : BaseCard
    {

        public override int Id
        {
            get
            {
                return 22;
            }
        }

        public override bool Ability()
        {
            throw new System.NotImplementedException();
        }
        /* 
        private Tile _moveTo;

        public override bool Ability()
        {
            // TODO increase card size
            //Select tile to move to
            Vector2 tilePos = ClickOnTile().position;
            player.MoveToTile(tilePos);
            return true;
        }

        private Tile ClickOnTile()
        {
            Board.Board board = BoardManager.instance.board.GetComponent<Board.Board>();
            if (board.selectedTile != null)
            {
                board.selectedTile.Deselect();
            }
            StartCoroutine(WaitForNextSelected());
            return new Tile();
        }

        private IEnumerator WaitForNextSelected()
        {
            Board.Board board = BoardManager.instance.board.GetComponent<Board.Board>();
            while (board.selectedTile == null)
            {
                yield return null;
            }
            print("izaso sam");
            _moveTo = board.selectedTile;
        }
        */

    }

}