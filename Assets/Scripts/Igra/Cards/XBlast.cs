using UnityEngine;

namespace Scripts.Cards
{
    public class XBlast : BaseAttackCard
    {
        public override int Id
        {
            get
            {
                return 12;
            }
        }
        //TODO ne koristiit new

        public override bool Ability()
        {
            DmgTile(character.position.tile.Position + new Vector2Int(1, 1));
            DmgTile(character.position.tile.Position + new Vector2Int(1, -1));
            DmgTile(character.position.tile.Position + new Vector2Int(-1, 1));
            DmgTile(character.position.tile.Position + new Vector2Int(-1, -1));
            return true;
        }
    }
}