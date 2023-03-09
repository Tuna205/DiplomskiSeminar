using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Card Back", menuName = "Card Back")]
    public class CardBack : ScriptableObject
    {
        public Sprite artwork;
    }
}