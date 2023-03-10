using System.Collections;
using System.Collections.Generic;
using Characters;
using LevelObjects;
using Maps;
using ScriptableObjects.Managers;
using UnityEngine;

namespace Cards
{
    public abstract class BaseAttackCard : BaseCard
    {
        private Map _map;
        [SerializeField] private int _dmg = 1;

        public override void Awake()
        {
            base.Awake();
            _map = MapManager.Instance;
        }

        protected void DmgTile(Vector2Int pos)
        {
            Tile tile = PosToTile(pos);
            if (tile == null) return;
            _map.StartCoroutine(FlashColor(tile, Color.red));
            List<LevelObject> objectsOnTile = tile.ObjectsOnTile.FindAll(lo => lo is BaseCharacter);
            objectsOnTile.ForEach(lo => (lo as BaseCharacter).Hp.ChangeHp(-_dmg));
        }

        //vraca null ako je pozicija van mape
        protected Tile PosToTile(Vector2Int pos)
        {
            return _map.CheckInBounds(pos) ? _map.TileMatrix[pos.x, pos.y] : null;
        }

        protected void ChangeColor(Tile tile, Color color)
        {
            tile.GetComponent<SpriteRenderer>().color = color;
        }

        private IEnumerator FlashColor(Tile tile, Color color)
        {
            ChangeColor(tile, color);
            yield return new WaitForSecondsRealtime(1);
            ChangeColor(tile, Color.white);
        }
    }
}