using Maps;
using UnityEngine;

namespace LevelObjects
{
    public abstract class LevelObject : MonoBehaviour
    {
        protected Map map;
        public Vector2Int startPosition;
        protected Tile currentTile;

        public Tile CurrentTile => currentTile;
    }
}

