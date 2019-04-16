using System.Collections;
using UnityEngine;
using Scripts.Cards;
using Scripts.Map;
using ScriptableObjects.Managers;
using Scripts.Player;

namespace Scripts.Cards
{
    public abstract class BaseAttackCard : BaseCard
    {
        //TODO izvadi map
        protected Map.Map map;
        public int dmg = 1;

        public override void Awake(){
            base.Awake();
            //IdToCard.Instance.dict[Id] = this;
            map = MapManager.Instance.GetComponent<Map.Map>();
        }
        protected void DmgTile(Vector2Int pos)
        {
            if (!map.CheckInBounds(pos)) return;
            Tile tile = map.TileMatrix[pos.x, pos.y];
            map.StartCoroutine(FlashColor(tile, Color.red));
            //koristi Scriptable object
            //TODO malo ljepse
            if(map.player1Position.tile == tile)
            {
                map.player1Position.character.GetComponent<BaseCharacter>().Hp.ChangeHp(-dmg);
            }

            if (map.player2Position.tile == tile)
            {
                map.player2Position.character.GetComponent<BaseCharacter>().Hp.ChangeHp(-dmg);
            }
            
            
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