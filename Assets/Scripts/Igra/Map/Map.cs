using ScriptableObjects.Managers;
using UnityEngine;

namespace Scripts.Map
{
    //TODO tilemap??
    public class Map : MonoBehaviour
    {
        public int sizeX, sizeY;

        public BackgroundSpriteManager backgroundSpriteManager;
        public GameObject tilePrefab;

        public PlayerBombs player1Bombs;
        public PlayerBombs player2Bombs;

        //public ObstacleList obstacleList;


        private Tile[,] _tileMatrix;
        //za 4x4 dobro je (-2,4,0)
        private Vector3 _startCoordinates;
        private Vector2 _tileSize;

        private SelectedTiles _selectedTiles;

        public Tile[,] TileMatrix
        {
            get
            {
                return _tileMatrix;
            }
        }

        private void Awake()
        {
            _tileMatrix = new Tile[sizeX, sizeY];
            //_startCoordinates = new Vector3(-9f, 4.5f, 0f);
            _selectedTiles = SelectedTiles.CreateInstance();
            Vector3 tmp = this.transform.localScale;
            _tileSize = new Vector2(tmp.x * 0.32f, tmp.y * 0.32f);
            SetupMap();
        }

        private void SetupMap()
        {
            Vector3 _currentCoordinates = this.transform.position;
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    GameObject go = GameObject.Instantiate(tilePrefab, _currentCoordinates, Quaternion.identity, this.transform);
                    Tile newTile = go.GetComponent<Tile>();
                    Sprite sprite = FindTileSprite(i, j);
                    newTile.Init(new Vector2Int(i, j), sprite, _selectedTiles);
                    _tileMatrix[i, j] = newTile;
                    _currentCoordinates.x += _tileSize.x;
                }
                _currentCoordinates.x -= _tileSize.x * sizeY;
                _currentCoordinates.y -= _tileSize.y;
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
            return (pos.x >= 0 && pos.x < sizeX && pos.y >= 0 && pos.y < sizeY);
        }


        private Sprite FindTileSprite(int x, int y)
        {
            if (x == 0 && y == 0) return backgroundSpriteManager.topLeft;
            if (x == 0 && y == sizeY - 1) return backgroundSpriteManager.topRight;
            if (x == 0) return backgroundSpriteManager.topCenter;

            if (x == sizeX - 1 && y == 0) return backgroundSpriteManager.bottomLeft;
            if (x == sizeX - 1 && y == sizeY - 1) return backgroundSpriteManager.bottomRight;
            if (x == sizeX - 1) return backgroundSpriteManager.bottomCenter;

            if (y == 0) return backgroundSpriteManager.left;
            if (y == sizeY - 1) return backgroundSpriteManager.right;
            return backgroundSpriteManager.center;
        }
    }
}