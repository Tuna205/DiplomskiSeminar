using System.Collections.Generic;

namespace Maps
{
    public class SelectedTiles
    {
        private readonly List<Tile> _selectedTiles;

        private static SelectedTiles _instance = null;
        public static SelectedTiles Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SelectedTiles();
                }
                return _instance;
            }
        }

        private SelectedTiles()
        {
            _selectedTiles = new List<Tile>();
        }

        public void Add(Tile position)
        {
            _selectedTiles.Add(position);
        }

        public void Remove(Tile position)
        {
            _selectedTiles.Remove(position);
        }

        public void DeselectAll()
        {
            for (int i = _selectedTiles.Count - 1; i >= 0; i--)
            {
                _selectedTiles[i].Deselect();
            }
        }
    }
}