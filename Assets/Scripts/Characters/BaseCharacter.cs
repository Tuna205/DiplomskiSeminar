using LevelObjects;
using Maps;
using Players;
using ScriptableObjects.Managers;
using UnityEngine;

namespace Characters
{
    public abstract class BaseCharacter : LevelObject
    {
        public HealthPoints hp;
        public PlayerBombs enemyBombs;//? kad se makne makni PlayerBombs, premjesti u Player i EnemyPlayer

        public HealthPoints Hp => hp;

        private bool MoveToTileLogic(Vector2Int newPos)
        {
            if (!map.CheckInBounds(newPos)) { return false; }
            currentTile?.RemoveFromTile(this);
            currentTile = map.TileMatrix[newPos.x, newPos.y];
            currentTile.AddToTile(this);
            return true;
        }

        public bool MoveToTile(Vector2Int newPos)
        {
            bool success = MoveToTileLogic(newPos);
            if (!success) return false;

            //TODO make movement animation
            this.transform.position = currentTile.transform.position;
            return true;
        }

        protected void Awake()
        {
            map = MapManager.Instance;
        }

        protected void Start()
        {
            MoveToTileLogic(startPosition);
            this.transform.position = currentTile.transform.position;
        }
    }
}