using System.Collections.Generic;
using UnityEngine;
using Scripts.Cards;

namespace Scripts.Cards
{
    //[CreateAssetMenu(fileName = "New Id to card", menuName = "ScriptableObjects/Background Sprites")]
    public class IdToCard : ScriptableObject
    {
        private static IdToCard _inst;
        public static IdToCard Instance
        {
            get
            {
                if (_inst == null)
                {
                    _inst = ScriptableObject.CreateInstance<IdToCard>();
                }
                return _inst;
            }
        }

        //Updejta se na Init u BaseCard
        public Dictionary<int, BaseCard> dict = new Dictionary<int, BaseCard>();
    }
}
