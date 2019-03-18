using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects.Managers;
using Map.Interfaces;
using Scripts.Player;

namespace Scripts.Map
{
    [CreateAssetMenu(fileName = "New Objects On Tile", menuName = "ScriptableObjects/Background Sprites")]
    public class ObjectsOnTile : ScriptableObject {
        public Vector2Int tilePosition;
        public List<IBomb> player1Bombs;
        public List<IBomb> player2Bombs;

        public Player.Player playerOnTile;

        public IObstacle obstacle;

        private void Init(Vector2Int tilePosition){
            this.tilePosition = tilePosition;
            player1Bombs = new List<IBomb>();
            player2Bombs = new List<IBomb>();
            //nesto kad nema playera
            playerOnTile = null;
            //nesto kada nema obstaclea
            obstacle = null;
        }

        public static ObjectsOnTile CreateInstance(Vector2Int tilePosition){
            ObjectsOnTile objs = ScriptableObject.CreateInstance<ObjectsOnTile>();
            objs.Init(tilePosition);
            return objs;
        }
    }
}