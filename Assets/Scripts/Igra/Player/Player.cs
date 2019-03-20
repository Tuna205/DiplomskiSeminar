using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Map;
using ScriptableObjects.Managers;

namespace Scripts.Player{
    public class Player : MonoBehaviour{
        private PlayerHp _playerHp;
        private Map.Map _map;
        public PlayerPosition playerPosition;

        public PlayerBombs playerBombs;
        
        private void Awake(){
            _map = MapManager.Instance.GetComponent<Map.Map>();
        }

        private void Start(){
            playerPosition.tile = _map.TileMatrix[0,0];
            this.transform.position = playerPosition.tile.transform.position;
        }

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

            playerPosition.tile = _map.TileMatrix[newPos.x, newPos.y];
            //TODO make movement animation
            this.transform.position = playerPosition.tile.transform.position;
            return true;
        }
        
        private void Update(){
            if(Input.GetKeyDown(KeyCode.W)){
                MoveToTile(playerPosition.tile.Position + new Vector2Int(-1,0));
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                MoveToTile(playerPosition.tile.Position + new Vector2Int(1, 0));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                MoveToTile(playerPosition.tile.Position + new Vector2Int(0, 1));
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveToTile(playerPosition.tile.Position + new Vector2Int(0, -1));
            }
        }
        
    }
}