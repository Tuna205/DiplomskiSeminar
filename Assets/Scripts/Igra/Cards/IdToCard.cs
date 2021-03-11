using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Cards
{
    public class IdToCard
    {
        private static IdToCard _inst;
        public static IdToCard Instance
        {
            get
            {
                if (_inst == null)
                {
                    _inst = new IdToCard();
                }
                return _inst;
            }
        }

        public Dictionary<int, BaseCard> dict = new Dictionary<int, BaseCard>();
    }
}
