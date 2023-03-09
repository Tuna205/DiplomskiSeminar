using Characters;
using UnityEngine;

namespace Players
{
    public class PlayerCharacter : BaseCharacter
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                MoveToTile(currentTile.Position + new Vector2Int(-1, 0));
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                MoveToTile(currentTile.Position + new Vector2Int(1, 0));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                MoveToTile(currentTile.Position + new Vector2Int(0, 1));
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveToTile(currentTile.Position + new Vector2Int(0, -1));
            }
        }
    }
}