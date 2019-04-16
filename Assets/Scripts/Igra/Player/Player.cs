using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Map;
using ScriptableObjects.Managers;
using Scripts.Player;

namespace Scripts.Player{
    public class Player : BaseCharacter{

        public bool MoveToTile(Vector2Int newPos)
        {
            if (!_map.CheckInBounds(newPos))
            {
                Debug.Log($"Position {newPos} is out of bounds");
                return false;
            }
            /* If occupied
            if (_map.TileMatrix[(int)newPos.x, (int)newPos.y].GetCharacter() != null)
            {
                Debug.Log($"Position {newPos} is ocupied");
                return false;
            }
            */

            position.tile = _map.TileMatrix[newPos.x, newPos.y];
            //TODO make movement animation
            this.transform.position = position.tile.transform.position;
            return true;
        }
        
        private void Update(){
            if(Input.GetKeyDown(KeyCode.W)){
                MoveToTile(position.tile.Position + new Vector2Int(-1,0));
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                MoveToTile(position.tile.Position + new Vector2Int(1, 0));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                MoveToTile(position.tile.Position + new Vector2Int(0, 1));
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveToTile(position.tile.Position + new Vector2Int(0, -1));
            }
        }
        
    }
}