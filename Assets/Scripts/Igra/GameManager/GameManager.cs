using Scripts.Cards;
using Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GM
{
    public enum TurnState
    {
        PlayerTurn,
        EnemyTurn,
        Resolve
    }
    public class GameManager : MonoBehaviour
    {

        public HumanPlayer humanPlayer;

        public static Action onPlayerTurnStart;
        public static Action onPlayerTurnEnd;
        public static Action onEnemyTurnStart;
        public static Action onEnemyTurnEnd;
        public static Action onResolveStart;
        public static Action onResolveEnd;

        public bool firstTurnPlayer = true; // enum

        private List<BaseCard> cardQueue; //nova klasa
        private TurnState currentState;

        public static int numCardsToPlay = 3;

        private int playerCardsPlayed = 0;
        private int enemyCardsPlayed = 0;

        public List<BaseCard> CardQueue => cardQueue;

        public void PlayerTurnStart()
        {
            onPlayerTurnStart?.Invoke();
        }

        public void PlayerTurnEnd()
        {
            playerCardsPlayed++;
            onPlayerTurnEnd?.Invoke();
            NextTurnState();
        }

        public void EnemyTurnStart()
        {
            onEnemyTurnStart?.Invoke();
            //cardQueue.Add(enemy.ai.PlayCard(true));
            EnemyTurnEnd();
        }

        public void EnemyTurnEnd()
        {
            onEnemyTurnEnd?.Invoke();
            enemyCardsPlayed++;
            NextTurnState();
        }

        private IEnumerator ResolveRutine()
        {
            for (int i = 0; i < cardQueue.Count; i++)
            {
                cardQueue[i].Ability();
                yield return new WaitForSecondsRealtime(1);
            }
            cardQueue.Clear();
        }

        public void Resolve()
        {
            onResolveStart?.Invoke();
            StartCoroutine(ResolveRutine());

            onResolveEnd?.Invoke();
            NextTurnState();
        }

        private void NextTurnState()
        {
            if (playerCardsPlayed == numCardsToPlay && playerCardsPlayed == enemyCardsPlayed)
            {
                Debug.Log("RESOLVE");
                currentState = TurnState.Resolve;
                playerCardsPlayed = 0;
                enemyCardsPlayed = 0;
                Resolve();
            }

            else if (currentState == TurnState.PlayerTurn)
            {
                currentState = TurnState.EnemyTurn;
                EnemyTurnStart();
            }

            else if (currentState == TurnState.EnemyTurn)
            {
                currentState = TurnState.PlayerTurn;
                PlayerTurnStart();
            }
            else if (currentState == TurnState.Resolve)
            {
                if (firstTurnPlayer == true)
                {
                    //ako je player prvi onda nakon 3 poteza igra enemy prvi
                    currentState = TurnState.EnemyTurn;
                    EnemyTurnStart();
                    firstTurnPlayer = !firstTurnPlayer;
                }
                else
                {
                    currentState = TurnState.PlayerTurn;
                    PlayerTurnStart();
                    firstTurnPlayer = !firstTurnPlayer;
                }
            }
        }

        private void Awake()
        {
            cardQueue = new List<BaseCard>();
        }

        private void Start()
        {
            humanPlayer.hand.onCardPlayed += PlayerTurnEnd;

            if (firstTurnPlayer == true)
            {
                this.currentState = TurnState.PlayerTurn;
                PlayerTurnStart();
            }
            else
            {
                this.currentState = TurnState.EnemyTurn;
                EnemyTurnStart();
            }
        }

        private void OnDestroy()
        {
            humanPlayer.hand.onCardPlayed -= PlayerTurnEnd;
        }
    }
}