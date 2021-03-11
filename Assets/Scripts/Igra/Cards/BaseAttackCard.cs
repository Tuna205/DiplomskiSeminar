using Scripts.LevelObjects;
using Scripts.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Cards
{
    public abstract class BaseAttackCard : BaseCard
    {
        //TODO izvadi map
        protected Map.Map map;
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
            if (!map.CheckInBounds(pos)) return null;
            return map.TileMatrix[pos.x, pos.y];
        }

        protected void ChangeColor(Tile tile, Color color)
        {
            tile.GetComponent<SpriteRenderer>().color = color;
        }

        protected IEnumerator FlashColor(Tile tile, Color color)
        {
            ChangeColor(tile, color);
            yield return new WaitForSecondsRealtime(1);
            ChangeColor(tile, Color.white);
        }
    }
}