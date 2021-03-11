using System.Collections.Generic;

namespace Scripts.Map
{
    public class SelectedTiles
    {
        private List<Tile> selectedTiles;

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
            selectedTiles = new List<Tile>();
        }

        public void Add(Tile position)
        {
            selectedTiles.Add(position);
        }

        public void Remove(Tile position)
        {
            selectedTiles.Remove(position);
        }

        public void DeselectAll()
        {
            for (int i = selectedTiles.Count - 1; i >= 0; i--)
            {
                selectedTiles[i].Deselect();
            }
        }
    }
}