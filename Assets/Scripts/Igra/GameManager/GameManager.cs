using UnityEngine;
using System.Collections.Generic;
using Scripts.Cards;

namespace Scripts.GM
{
    public enum TurnState{
        PlayerTurn,
        EnemyTurn,
        Resolve
    }
    public class GameManager : MonoBehaviour
    {
        private List<BaseCard> queue;
        private TurnState currentState;

        public int numCardsToPlay = 3;

        private int playerCardsPlayed = 0;

        private int enemyCardsPlayed = 0;

        public void PlayerTurn(){
            //indikator za player turn
            //Omoguci da player igra karte iz ruke
        }

        public void EnemyTurn(){
            //hook upaj enemy ai
        }

        public void Resolve(){
            for(int i = 0; i < queue.Count; i++){
                queue[i].Ability();
            }
        }

        private void NextTurnState(){
            if (playerCardsPlayed == enemyCardsPlayed && playerCardsPlayed == numCardsToPlay)
            {
                currentState = TurnState.Resolve;
                playerCardsPlayed = 0;
                enemyCardsPlayed = 0;
            }

            else if(currentState == TurnState.PlayerTurn){
                currentState = TurnState.EnemyTurn;
                playerCardsPlayed++;
            }

            else if(currentState == TurnState.PlayerTurn)
            {
                currentState = TurnState.Resolve;
                enemyCardsPlayed++;
            }
        }

        void Update(){
            switch(currentState){
                case TurnState.PlayerTurn:
                    PlayerTurn();
                    break;

                case TurnState.EnemyTurn:
                    EnemyTurn();
                    break;

                case TurnState.Resolve:
                    Resolve();
                    break;
            }
        }
    }
}