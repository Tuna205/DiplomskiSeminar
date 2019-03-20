using UnityEngine;
using System.Collections.Generic;
using Scripts.Cards;

namespace Scripts.Hand
{
    public class Hand : MonoBehaviour
    {
        public int maxCards = 5;
        public Vector3 position;
        //public CardsInHand cardsInHand;

        //TODO promijeni
        public Deck.Deck _deck;

        private List<BaseCard> _hand;

        public void Draw(int n){
            if (_hand.Count + n > maxCards)
            {
                //TODO discard cards
                print("To many cards in hand");
            }
            //TODO kada dodam deck
            _hand.AddRange(_deck.Draw(n));
            ShowCardsInHand();
        }
        //TODO display cards
        //Promijeni algoritam!!!
        public void ShowCardsInHand()
        {
            //hack 1
            for (int i = 0; i < this.transform.childCount; i++)
            {
                Destroy(this.transform.GetChild(i).gameObject);
            }

            Vector3 position = this._deck.gameObject.transform.position + new Vector3(2, 0, 0);

            for (int i = 0; i < _hand.Count; i++)
            {
                var tmp = Instantiate(_hand[i], position, Quaternion.identity, this.transform);
                tmp.name = _hand[i].name;
                //hack 2 - cards lose box coliders because of hack 1 ??
                tmp.GetComponent<BoxCollider2D>().enabled = true;
                _hand[i] = tmp;
                position += new Vector3(1, 0, 0);
            }
        }

        private void Awake(){
            //_hand = cardsInHand.cards;
            _hand = new List<BaseCard>();
        }

        private void Start(){
            Draw(maxCards);
        }
    }
}