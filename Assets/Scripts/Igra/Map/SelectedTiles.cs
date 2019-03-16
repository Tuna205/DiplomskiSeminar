using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects.Managers;
using Map.Interfaces;

namespace Scripts.Map
{
    public class SelectedTiles : ScriptableObject
    {
        public List<Tile> selectedTiles;

        private void Init()
        {
            selectedTiles = new List<Tile>();
        }

        public static SelectedTiles CreateInstance()
        {
            SelectedTiles objs = ScriptableObject.CreateInstance<SelectedTiles>();
            objs.Init();
            return objs;
        }

        public void Add(Tile position){
            selectedTiles.Add(position);
        }

        public void Remove(Tile position){
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