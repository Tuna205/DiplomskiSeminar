using System.Collections;
using UnityEngine;
using Scripts.Player;
using Scripts.Map;
using ScriptableObjects.Managers;

namespace Scripts.Player
{
    public abstract class BaseCharacter : MonoBehaviour
    {
        protected HealthPoints _hp;

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

        protected void Awake()
        {
            _map = MapManager.Instance.GetComponent<Map.Map>();
        }

        protected void Start()
        {
            position.tile = _map.TileMatrix[startPosition.x, startPosition.y];
            position.character = this.gameObject;
            this.transform.position = position.tile.transform.position;
            _hp = HealthPoints.CreateInstance(5);
        }
    }
}