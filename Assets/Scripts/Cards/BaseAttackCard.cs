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
        private Map map;
        public int dmg = 1;

        public override void Awake()
        {
            base.Awake();
            map = MapManager.Instance;
        }

        protected void DmgTile(Vector2Int pos)
        {
            Tile tile = PosToTile(pos);
            if (tile == null) return;
            map.StartCoroutine(FlashColor(tile, Color.red));
            List<LevelObject> objectsOnTile = tile.ObjectsOnTile.FindAll(lo => lo is BaseCharacter);
            objectsOnTile.ForEach(lo => (lo as BaseCharacter).Hp.ChangeHp(-dmg));
        }

        //vraca null ako je pozicija van mape
        protected Tile PosToTile(Vector2Int pos)
        {
            return map.CheckInBounds(pos) ? map.TileMatrix[pos.x, pos.y] : null;
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