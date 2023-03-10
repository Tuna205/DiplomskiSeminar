using ScriptableObjects.Managers;
using UnityEngine;

namespace Maps
{
    //TODO tilemap??
    public class Map : MonoBehaviour
    {
        [SerializeField] private int _sizeX, _sizeY;

        [SerializeField] private BackgroundSpriteManager _backgroundSpriteManager;
        [SerializeField] private GameObject _tilePrefab;

        private Tile[,] _tileMatrix;
        private Vector2 _tileSize;

        public Tile[,] TileMatrix => _tileMatrix;

        private void Awake()
        {
            _tileMatrix = new Tile[_sizeX, _sizeY];
            Vector3 localScale = this.transform.localScale;
            _tileSize = new Vector2(localScale.x * 0.32f, localScale.y * 0.32f);
            SetupMap();
        }

        private void SetupMap()
        {
            Vector3 currentCoordinates = this.transform.position;
            for (int i = 0; i < _sizeX; i++)
            {
                for (int j = 0; j < _sizeY; j++)
                {
                    GameObject go = GameObject.Instantiate(_tilePrefab, currentCoordinates, Quaternion.identity, this.transform);
                    Tile newTile = go.GetComponent<Tile>();
                    Sprite sprite = FindTileSprite(i, j);
                    newTile.Init(new Vector2Int(i, j), sprite);
                    _tileMatrix[i, j] = newTile;
                    currentCoordinates.x += _tileSize.x;
                }
                currentCoordinates.x -= _tileSize.x * _sizeY;
                currentCoordinates.y -= _tileSize.y;
            }
        }

        public static int CalculateTileDistance(Tile t1, Tile t2)
        {
            int difX = Mathf.Abs(t1.Position.x - t2.Position.x);
            int difY = Mathf.Abs(t1.Position.y - t2.Position.y);

            return difX + difY;
        }

        public bool CheckInBounds(Vector2Int pos)
        {
            return (pos.x >= 0 && pos.x < _sizeX && pos.y >= 0 && pos.y < _sizeY);
        }

        private Sprite FindTileSprite(int x, int y)
        {
            if (x == 0 && y == 0) return _backgroundSpriteManager.topLeft;
            if (x == 0 && y == _sizeY - 1) return _backgroundSpriteManager.topRight;
            if (x == 0) return _backgroundSpriteManager.topCenter;

            if (x == _sizeX - 1 && y == 0) return _backgroundSpriteManager.bottomLeft;
            if (x == _sizeX - 1 && y == _sizeY - 1) return _backgroundSpriteManager.bottomRight;
            if (x == _sizeX - 1) return _backgroundSpriteManager.bottomCenter;

            if (y == 0) return _backgroundSpriteManager.left;
            if (y == _sizeY - 1) return _backgroundSpriteManager.right;
            return _backgroundSpriteManager.center;
        }
    }
}