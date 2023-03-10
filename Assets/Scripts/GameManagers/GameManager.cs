using System;
using System.Collections;
using System.Collections.Generic;
using Cards;
using Players;
using UnityEngine;

namespace GameManagers
{
    public enum TurnState
    {
        PlayerTurn,
        EnemyTurn,
        Resolve
    }
    public class GameManager : MonoBehaviour
    {

        [SerializeField] private HumanPlayer _humanPlayer;

        public static Action onPlayerTurnStart;
        public static Action onPlayerTurnEnd;
        public static Action onEnemyTurnStart;
        public static Action onEnemyTurnEnd;
        public static Action onResolveStart;
        public static Action onResolveEnd;

        private List<BaseCard> _cardQueue; //nova klasa
        private TurnState _currentState;

        public static int _numCardsToPlay = 3;

        private int _playerCardsPlayed = 0;
        private int _enemyCardsPlayed = 0;

        public List<BaseCard> CardQueue => _cardQueue;

        public void PlayerTurnStart()
        {
            onPlayerTurnStart?.Invoke();
        }

        public void PlayerTurnEnd()
        {
            _playerCardsPlayed++;
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
            _enemyCardsPlayed++;
            NextTurnState();
        }

        private IEnumerator ResolveRoutine()
        {
            foreach (var baseCard in _cardQueue)
            {
                baseCard.Ability();
                yield return new WaitForSecondsRealtime(1);
            }

            _cardQueue.Clear();
        }

        public void Resolve()
        {
            onResolveStart?.Invoke();
            StartCoroutine(ResolveRoutine());

            onResolveEnd?.Invoke();
            NextTurnState();
        }

        private void NextTurnState()
        {
            if (_playerCardsPlayed == _numCardsToPlay && _playerCardsPlayed == _enemyCardsPlayed)
            {
                Debug.Log("RESOLVE");
                _currentState = TurnState.Resolve;
                _playerCardsPlayed = 0;
                _enemyCardsPlayed = 0;
                Resolve();
            }

            else if (_currentState == TurnState.PlayerTurn)
            {
                _currentState = TurnState.EnemyTurn;
                EnemyTurnStart();
            }

            else if (_currentState == TurnState.EnemyTurn)
            {
                _currentState = TurnState.PlayerTurn;
                PlayerTurnStart();
            }
            else if (_currentState == TurnState.Resolve)
            {
                //ako je player prvi onda nakon 3 poteza igra enemy prvi
                _currentState = TurnState.EnemyTurn;
                EnemyTurnStart();
            }
        }

        private void Awake()
        {
            _cardQueue = new List<BaseCard>();
        }

        private void Start()
        {
            _humanPlayer.Hand.onCardPlayed += PlayerTurnEnd;
            this._currentState = TurnState.PlayerTurn;
                PlayerTurnStart();

        }

        private void OnDestroy()
        {
            _humanPlayer.Hand.onCardPlayed -= PlayerTurnEnd;
        }
    }
}