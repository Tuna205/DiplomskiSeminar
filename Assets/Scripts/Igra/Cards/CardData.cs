using UnityEngine;

namespace Scripts.Cards{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class CardData : ScriptableObject{
        public new string name;
        public string description;
        public Sprite artwork;
    }
}