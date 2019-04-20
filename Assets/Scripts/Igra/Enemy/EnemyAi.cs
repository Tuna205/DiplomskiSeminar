using System.Collections;
using UnityEngine;

namespace Scripts.AI
{
    public abstract class EnemyAi : ScriptableObject
    {
        public abstract void PlayCard();

        public abstract void Init(Hand.Hand hand);
    }
}