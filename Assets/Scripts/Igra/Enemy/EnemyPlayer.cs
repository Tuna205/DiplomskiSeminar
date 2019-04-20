using System.Collections;
using UnityEngine;
using Scripts.Player;
using Scripts.Map;
using ScriptableObjects.Managers;
using Scripts.Deck;
using Scripts.GM;
using Scripts.AI;

namespace Scripts.Cards
{
    public class EnemyPlayer : BaseCharacter
    {
        public Hand.Hand hand;
        //public GameManager gm;

        public EnemyAi ai;

        private new void Awake(){
            base.Awake();
            ai.Init(hand);
        }

        public void DoTurn(){
            ai.PlayCard();
        }

        void Update(){
            if(Input.GetKeyDown(KeyCode.Space)){
                DoTurn();
            }
        }

    }
}