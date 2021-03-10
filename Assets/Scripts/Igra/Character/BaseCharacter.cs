using ScriptableObjects.Managers;
using Scripts.Map;
using UnityEngine;

namespace Scripts.LevelObjects
{
    public abstract class BaseCharacter : LevelObject
    {
        public HealthPoints _hp;
        public PlayerBombs enemyBombs;//?
        public int maxHp;//?

        public HealthPoints Hp => _hp;

        private bool MoveToTileLogic(Vector2Int newPos)
        {
            if (!_map.CheckInBounds(newPos)) { return false; }
            _currentTile?.RemoveFromTile(this);
            _currentTile = _map.TileMatrix[newPos.x, newPos.y];
            _currentTile.AddToTile(this);
            return true;
        }

        public bool MoveToTile(Vector2Int newPos)
        {
            bool success = MoveToTileLogic(newPos);
            if (!success) return false;

            //TODO make movement animation
            this.transform.position = _currentTile.transform.position;
            return true;
        }

        protected void Awake()
        {
            _map = MapManager.Instance.GetComponent<Map.Map>();
        }

        protected void Start()
        {
            MoveToTileLogic(startPosition);
            this.transform.position = _currentTile.transform.position;
            //_hp = HealthPoints.CreateInstance(5);
        }
    }
}