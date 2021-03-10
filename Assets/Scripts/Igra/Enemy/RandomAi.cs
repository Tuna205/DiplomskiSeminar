using Scripts.Cards;
using UnityEngine;

namespace Scripts.AI
{
    [CreateAssetMenu(fileName = "New RandomAi", menuName = "AI/RandomAi")]
    public class RandomAi : EnemyAi
    {
        private Hand.Hand _hand;

        public override void Init(Hand.Hand hand)
        {
            _hand = hand;
        }

        public override BaseCard PlayCard(bool dontPlay)
        {
            if (_hand.NumOfCards() == 0) return null; //TODO VELIKI OPREZ??
            int rand = UnityEngine.Random.Range(0, _hand.NumOfCards() - 1);
            BaseCard card = _hand.transform.GetChild(rand).GetComponent<BaseCard>();
            Debug.Log($"Enemy plays: {card.name}");
            card.Play(dontPlay);
            Debug.Log($"Enemy added {card.name}");
            return card;
        }
    }
}