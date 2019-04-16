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
            DmgTile(player.position.tile.Position + new Vector2Int(1, 1));
            DmgTile(player.position.tile.Position + new Vector2Int(1, -1));
            DmgTile(player.position.tile.Position + new Vector2Int(-1, 1));
            DmgTile(player.position.tile.Position + new Vector2Int(-1, -1));
            return true;
        }
    }
}