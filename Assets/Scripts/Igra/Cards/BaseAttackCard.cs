using ScriptableObjects.Managers;
using Scripts.Map;
using Scripts.Player;
using System.Collections;
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
            //IdToCard.Instance.dict[Id] = this;
            map = MapManager.Instance.GetComponent<Map.Map>();
        }
        protected void DmgTile(Vector2Int pos)
        {
            Tile tile = PosToTile(pos);
            if (tile == null) return;
            map.StartCoroutine(FlashColor(tile, Color.red));
            //koristi Scriptable object
            //TODO malo ljepse
            if (map.player1Position.tile == tile)
            {
                map.player1Position.character.GetComponent<BaseCharacter>().Hp.ChangeHp(-dmg);
            }

            if (map.player2Position.tile == tile)
            {
                map.player2Position.character.GetComponent<BaseCharacter>().Hp.ChangeHp(-dmg);
            }
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