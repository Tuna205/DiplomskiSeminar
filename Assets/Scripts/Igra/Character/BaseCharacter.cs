using System.Collections;
using UnityEngine;
using Scripts.Player;
using Scripts.Map;
using ScriptableObjects.Managers;

namespace Scripts.Player
{
    public abstract class BaseCharacter : MonoBehaviour
    {
        public HealthPoints _hp;

        protected Map.Map _map;
        public CharacterPosition position;

        public PlayerBombs enemyBombs;
        public int maxHp;
        public Vector2Int startPosition;

        public HealthPoints Hp{
            get{
                return _hp;
            }
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

            position.tile = _map.TileMatrix[newPos.x, newPos.y];
            //TODO make movement animation
            this.transform.position = position.tile.transform.position;
            return true;
        }

        protected void Awake()
        {
            _map = MapManager.Instance.GetComponent<Map.Map>();
        }

        protected void Start()
        {
            position.tile = _map.TileMatrix[startPosition.x, startPosition.y];
            position.character = this.gameObject;
            this.transform.position = position.tile.transform.position;
            //_hp = HealthPoints.CreateInstance(5);
        }
    }
}