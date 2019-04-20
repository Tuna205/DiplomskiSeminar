using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Map;
using ScriptableObjects.Managers;
using Scripts.Player;

namespace Scripts.Player{
    public class Player : BaseCharacter{
        
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