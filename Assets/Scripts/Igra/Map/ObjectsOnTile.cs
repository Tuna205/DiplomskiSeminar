using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects.Managers;
using Map.Interfaces;
using Scripts.Player;

namespace Scripts.Map
{
    public class ObjectsOnTile : ScriptableObject {

        //DRUGI SCRIPTABLE OBJECT MOZDA
        public Vector2Int tilePosition;
        public List<IBomb> player1Bombs;
        public List<IBomb> player2Bombs;

        public Player.Player playerOnTile;

        //public IObstacle obstacle;

        private void Init(Vector2Int tilePosition){
            this.tilePosition = tilePosition;
            player1Bombs = new List<IBomb>();
            player2Bombs = new List<IBomb>();
            //jos se razmatra
            playerOnTile = PlayerManager.Instance.GetComponent<Player.Player>();
            //nesto kada nema obstaclea
            //obstacle = 
        }

        public static ObjectsOnTile CreateInstance(Vector2Int tilePosition){
            ObjectsOnTile objs = ScriptableObject.CreateInstance<ObjectsOnTile>();
            objs.Init(tilePosition);
            return objs;
        }
    }
}