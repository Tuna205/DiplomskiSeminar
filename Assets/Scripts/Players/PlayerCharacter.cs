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
                MoveToTile(_currentTile.Position + new Vector2Int(-1, 0));
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                MoveToTile(_currentTile.Position + new Vector2Int(1, 0));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                MoveToTile(_currentTile.Position + new Vector2Int(0, 1));
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveToTile(_currentTile.Position + new Vector2Int(0, -1));
            }
        }
    }
}