using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Scripts.LevelObjects;

namespace Scripts.Map
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    public class Tile : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider;
        private SelectedTiles _selectedTiles;
        private Vector2Int _position;
        private List<LevelObject> _objectsOnTile = new List<LevelObject>();

        public Vector2Int Position => _position;
        public bool CanBeSelected { get; set; }
        public List<LevelObject> ObjectsOnTile => _objectsOnTile;

        private UnityEvent _onSelectEvent;

        //Call this function first
        public void Init(Vector2Int position, Sprite sprite, SelectedTiles selectedTiles)
        {
            _position = position;
            _spriteRenderer = this.GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = sprite;
            _collider = this.GetComponent<Collider2D>();
            _selectedTiles = selectedTiles;
            _onSelectEvent = new UnityEvent();
        }

        public void AddToTile(LevelObject lvlObject)
        {
            _objectsOnTile.Add(lvlObject);
        }

        public void RemoveFromTile(LevelObject lvlObject)
        {
            if (_objectsOnTile.Contains(lvlObject))
            {
                _objectsOnTile.Remove(lvlObject);
            }
        }

        public void Select(Color selectColor)
        {
            _selectedTiles.DeselectAll();
            _spriteRenderer.color = selectColor;
            //ubaci u listu
            _selectedTiles.Add(this);
        }

        public void Deselect()
        {
            _spriteRenderer.color = Color.white;
            //izbaci iz liste deselectanih
            _selectedTiles.Remove(this);
        }

        public void OnMouseDown()
        {
            if (CanBeSelected == false) return;
            //deselect other tiles
            Select(Color.cyan);
            //Treba biti event !!!
            //_onSelectEvent
        }
    }
}
