using Scripts.AI;
using Scripts.Player;
using UnityEngine;

namespace Scripts.Cards
{
    public class EnemyPlayer : BaseCharacter
    {
        public Hand.Hand hand;
        //public GameManager gm;

        public EnemyAi ai;

        private new void Awake()
        {
            base.Awake();
            ai.Init(hand);
        }

        public void DoTurn()
        {
            ai.PlayCard(false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DoTurn();
            }
        }

    }
}