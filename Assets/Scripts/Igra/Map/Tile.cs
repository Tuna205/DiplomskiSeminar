using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Map{

    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    public class Tile : MonoBehaviour
    {
        //image of the tile
        private SpriteRenderer _spriteRenderer;
        //collider for selecting this tile
        private Collider2D _collider;
        //saves data from objects on this tile

        private SelectedTiles _selectedTiles;
        private Vector2Int _position;

        public Vector2Int Position{
            get{return _position;}
        }

        //Call this function first
        public void Init(Vector2Int position, Sprite sprite, SelectedTiles selectedTiles){
            _position = position;
            _spriteRenderer = this.GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = sprite;
            _collider = this.GetComponent<Collider2D>();
            _selectedTiles = selectedTiles;
        }

        public void Select(Color selectColor)
        {
            _selectedTiles.DeselectAll();
            _spriteRenderer.color = selectColor;
            //ubaci u listu
            _selectedTiles.Add(this);
            print(_position);
        }

        public void Deselect()
        {
            _spriteRenderer.color = Color.white;
            //izbaci iz liste deselectanih
            _selectedTiles.Remove(this);
        }

        public void OnMouseDown()
        {
            //deselect other tiles
            Select(Color.cyan);
        }
    }
}
