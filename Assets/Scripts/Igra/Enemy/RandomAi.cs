using System;
using System.Collections;
using UnityEngine;
using Scripts.Hand;
using Scripts.Cards;

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

        public override void PlayCard()
        {
            System.Random rng = new System.Random();
            if(_hand.NumOfCards() == 0) return;
            int rand = rng.Next(0, _hand.NumOfCards() - 1);
            Debug.Log($"Enemy plays: ");
            _hand.transform.GetChild(rand).GetComponent<BaseCard>().Play();           
        }
    }
}