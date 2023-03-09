using System.Collections.Generic;
using Cards;
using UnityEngine;

namespace Decks
{
    [CreateAssetMenu(fileName = "New Deck list", menuName = "Deck list")]
    public class DeckList : ScriptableObject
    {
        public List<BaseCard> startDeckList;
    }
}