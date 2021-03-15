using Scripts.AI;
using Scripts.Player;
using Scripts.Hand;
using UnityEngine;
using Scripts.GM;
using System;

namespace Scripts.Enemy
{
    public class AiPlayer : Player.Player
    {
        public EnemyAi ai;

        private void Awake()
        {
            ai.Init(hand);
        }

        private void Start()
        {
            GameManager.onEnemyTurnStart += DoTurn; //TODO dodaj na stack
            //GameManager.onEnemyTurnEnd += TurnEnd;
            GameManager.onResolveEnd += DrawCards;
        }

        public void DoTurn()
        {
            ai.PlayCard(true);
        }

        private void DrawCards()
        {
            hand.Draw(GameManager.numCardsToPlay);
        }

        private void OnDestroy()
        {
            GameManager.onEnemyTurnStart -= DoTurn; //TODO dodaj na stack
            //GameManager.onEnemyTurnEnd += TurnEnd;
            GameManager.onResolveEnd -= DrawCards;
        }
    }
}
