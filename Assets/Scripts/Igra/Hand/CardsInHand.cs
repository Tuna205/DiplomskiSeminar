using System.Collections.Generic;
using UnityEngine;
using Scripts.Cards;

namespace Scripts.Hand
{
    [CreateAssetMenu(fileName = "New Cards in hand", menuName = "ScriptableObjects/Cards in hand")]
    public class CardsInHand : ScriptableObject
    {
        public List<BaseCard> cards = new List<BaseCard>();
    }
}