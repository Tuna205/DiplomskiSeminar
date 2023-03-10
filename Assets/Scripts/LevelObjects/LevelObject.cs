using Maps;
using UnityEngine;

namespace LevelObjects
{
    public abstract class LevelObject : MonoBehaviour
    {
        protected Map _map;
        [SerializeField] protected Vector2Int _startPosition;
        protected Tile _currentTile;

        public Tile CurrentTile => _currentTile;
    }
}

