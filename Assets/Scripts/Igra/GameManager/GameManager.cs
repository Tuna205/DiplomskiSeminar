using UnityEngine;
using System.Collections.Generic;
using Scripts.Cards;
using System.Collections;
using System;

namespace Scripts.GM
{
    public enum TurnState{
        PlayerTurn,
        EnemyTurn,
        Resolve
    }
    public class GameManager : MonoBehaviour
    {
        public Canvas PlayerTurnCanvas;
        public Canvas EnemyTurnCanvas;
        public Hand.Hand playerHand;

        public Hand.Hand enemyHand;
        public EnemyPlayer enemy;

        public bool firstTurnPlayer = true;

        private List<BaseCard> cardQueue;
        private TurnState currentState;

        public int numCardsToPlay = 3;

        private int playerCardsPlayed = 0;

        private int enemyCardsPlayed = 0;

        public List<BaseCard> CardQueue{
            get{
                return cardQueue;
            }
        }

        public void PlayerTurnStart(){
            //StartCoroutine(ShowCanvasForSecounds(PlayerTurnCanvas, 2));
            playerHand.CanPlayCards = true;
            //indikator za player turn
            //Omoguci da player igra karte iz ruke

        }

        public void PlayerTurnEnd()
        {
            playerCardsPlayed++;
            playerHand.CanPlayCards = false;
            NextTurnState();
        }


        public void EnemyTurnStart()
        {
            //StartCoroutine(ShowCanvasForSecounds(EnemyTurnCanvas, 2));
            //enemy igra kartu
            cardQueue.Add(enemy.ai.PlayCard(true));
            EnemyTurnEnd();
        }

        public void EnemyTurnEnd()
        {
            enemyCardsPlayed++;
            //enemy ai turn
            NextTurnState();
        }

        public void Resolve(){
            //TODO Polagano resolvanje karte po karte
            for(int i = 0; i < cardQueue.Count; i++){
                cardQueue[i].Ability();
            }
            
            playerHand.Draw(numCardsToPlay);
            enemyHand.Draw(numCardsToPlay);


            NextTurnState();
        }

        private void NextTurnState(){
            if (playerCardsPlayed == numCardsToPlay && playerCardsPlayed == enemyCardsPlayed)
            {
                currentState = TurnState.Resolve;
                playerCardsPlayed = 0;
                enemyCardsPlayed = 0;
                Resolve();
            }

            else if(currentState == TurnState.PlayerTurn){
                currentState = TurnState.EnemyTurn;
                EnemyTurnStart();
            }

            else if(currentState == TurnState.EnemyTurn)
            {
                currentState = TurnState.PlayerTurn;
                PlayerTurnStart();
            }
            else if(currentState == TurnState.Resolve){
                if(firstTurnPlayer == true){
                    //ako je player prvi onda nakon 3 poteza igra enemy prvi
                    
                    currentState = TurnState.EnemyTurn;
                    EnemyTurnStart();
                    firstTurnPlayer = !firstTurnPlayer;
                }
                else{
                    currentState = TurnState.PlayerTurn;
                    PlayerTurnStart();
                    firstTurnPlayer = !firstTurnPlayer;
                }
            }
        }

        private IEnumerator ShowCanvasForSecounds(Canvas c, int n){
            c.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(n);
            c.gameObject.SetActive(false);
        }

        private void Awake(){
            cardQueue = new List<BaseCard>();
        }

        private void Start(){
            if(firstTurnPlayer == true){
                this.currentState = TurnState.PlayerTurn;
                PlayerTurnStart();
            }
            else{
                this.currentState = TurnState.EnemyTurn;
                EnemyTurnStart();
            }
        }

        private void Update(){
            print($"Turn State = {currentState}");
            if(currentState == TurnState.PlayerTurn){
                if (playerHand.PlayedCard == true){
                    playerHand.PlayedCard = false;
                    PlayerTurnEnd();         
                }
            }
        }
    }
}