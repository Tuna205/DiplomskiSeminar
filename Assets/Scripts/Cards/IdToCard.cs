using System.Collections.Generic;

namespace Cards
{
    public class IdToCard
    {
        private static IdToCard _inst;
        public static IdToCard Instance
        {
            get { return _inst ??= new IdToCard(); }
        }

        public readonly Dictionary<int, BaseCard> dict = new Dictionary<int, BaseCard>();
    }
}
