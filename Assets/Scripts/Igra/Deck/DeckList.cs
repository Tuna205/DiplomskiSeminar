using Scripts.Cards;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Deck
{
    [CreateAssetMenu(fileName = "New Deck list", menuName = "Deck list")]
    public class DeckList : ScriptableObject
    {
        public List<BaseCard> startDeckList = new List<BaseCard>();
    }
}