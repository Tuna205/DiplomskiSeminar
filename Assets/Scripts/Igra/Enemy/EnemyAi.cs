using System.Collections;
using Scripts.Cards;
using UnityEngine;

namespace Scripts.AI
{
    public abstract class EnemyAi : ScriptableObject
    {
        public abstract BaseCard PlayCard(bool dontPlay);

        public abstract void Init(Hand.Hand hand);
    }
}