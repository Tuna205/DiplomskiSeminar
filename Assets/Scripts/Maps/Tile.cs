﻿using System;
using System.Collections.Generic;
using LevelObjects;
using UnityEngine;

namespace Maps
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    public class Tile : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Vector2Int _position;
        private SelectedTiles _selectedTiles;
        private readonly List<LevelObject> _objectsOnTile = new List<LevelObject>();

        public Vector2Int Position => _position;
        public bool CanBeSelected { get; set; }
        public List<LevelObject> ObjectsOnTile => _objectsOnTile;

        public Action<Vector2Int> onSelected;

        //Call this function first
        public void Init(Vector2Int position, Sprite sprite)
        {
            this._position = position;
            _spriteRenderer = this.GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = sprite;
            _selectedTiles = SelectedTiles.Instance;
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
            _selectedTiles.Add(this);
        }

        public void Deselect()
        {
            _spriteRenderer.color = Color.white;
            _selectedTiles.Remove(this);
        }

        public void OnMouseDown()
        {
            if (CanBeSelected == false) return;

            Select(Color.cyan);
            onSelected?.Invoke(Position);
        }
    }
}
