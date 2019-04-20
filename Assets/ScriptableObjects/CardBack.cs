using UnityEngine;

namespace ScriptableObjects.Cards
{
    [CreateAssetMenu(fileName = "New Card Back", menuName = "Card Back")]
    public class CardBack : ScriptableObject
    {
        public Sprite artwork;
    }
}