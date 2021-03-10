using Scripts.Map;
using UnityEngine;

namespace Scripts.LevelObjects
{
    public abstract class LevelObject : MonoBehaviour
    {
        protected Map.Map _map;
        public Vector2Int startPosition;
        protected Tile _currentTile;

        public Tile CurrentTile => _currentTile;
    }
}

