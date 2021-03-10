using ScriptableObjects.Managers;
using UnityEngine;

namespace Scripts.Cards
{
    public class Shoot : BaseAttackCard
    {
        public override int Id
        {
            get
            {
                return 13;
            }
        }

        public override void Awake()
        {
            base.Awake();
            //IdToCard.Instance.dict[Id] = this;
            map = MapManager.Instance.GetComponent<Map.Map>();
        }

        //TODO srediti orijentaciju da puca samo prema protivniku
        //TODO ne koristiit new
        public override bool Ability()
        {
            DmgTile(character.CurrentTile.Position + new Vector2Int(1, 0));
            DmgTile(character.CurrentTile.Position + new Vector2Int(-1, 0));
            DmgTile(character.CurrentTile.Position + new Vector2Int(0, 1));
            DmgTile(character.CurrentTile.Position + new Vector2Int(0, -1));

            DmgTile(character.CurrentTile.Position + new Vector2Int(2, 0));
            DmgTile(character.CurrentTile.Position + new Vector2Int(-2, 0));
            DmgTile(character.CurrentTile.Position + new Vector2Int(0, 2));
            DmgTile(character.CurrentTile.Position + new Vector2Int(0, -2));
            return true;
        }
    }
}