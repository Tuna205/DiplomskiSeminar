using UnityEngine;

namespace Scripts.Cards
{
    public class PBlast : BaseAttackCard
    {
        public override int Id
        {
            get
            {
                return 11;
            }
        }
        //TODO ne koristiit new

        public override bool Ability()
        {
            DmgTile(character.position.tile.Position + new Vector2Int(1, 0));
            DmgTile(character.position.tile.Position + new Vector2Int(-1, 0));
            DmgTile(character.position.tile.Position + new Vector2Int(0, 1));
            DmgTile(character.position.tile.Position + new Vector2Int(0, -1));
            return true;
        }
    }
}