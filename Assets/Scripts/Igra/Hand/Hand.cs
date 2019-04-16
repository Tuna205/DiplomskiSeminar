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

        private List<int> _handIds;

        private Vector3 lastCardPosition;

        //public CardsInHand cardsInHand;

        private void Awake()
        {
            //_hand = cardsInHand.cards;
            _handIds = new List<int>();
            //cardsInHand.cards.Clear();
        }

        private void Start()
        {
            //lastCardPosition = Vector3.zero;
            Draw(maxCards);
        }

        public void Draw(int n){
            if (_handIds.Count + n > maxCards)
            {
                //TODO discard cards
                print("To many cards in hand");
                return;
            }
            //TODO kada dodam deck
            List<int> addedCards = _deck.Draw(n);
            _handIds.AddRange(addedCards);
            foreach(int cardId in addedCards){
                InstantiateCard(IdToCard.Instance.dict[cardId]);
            }
        }

        //Uses localCardPosition for instantiate postion
        public void InstantiateCard(BaseCard card){
            var tmp = Instantiate(card, this.transform.position + lastCardPosition, Quaternion.identity, this.transform);
            lastCardPosition += new Vector3(3, 0, 0);
        }

        public void RemoveCard(BaseCard card)
        {
            //TODO if go none in hand
            _handIds.Remove(card.Id);
            int siblingIndex = card.transform.GetSiblingIndex();
            Destroy(card.gameObject);
            RearangeCards(siblingIndex);
        }

        //need number of cards and card child count from hand parent
        private void RearangeCards(int destroyedSiblingIndex){
            foreach(Transform t in this.transform){
                if(t.GetSiblingIndex() < destroyedSiblingIndex) continue;
                t.transform.position -= new Vector3(3, 0, 0);
            }
            lastCardPosition -= new Vector3(3, 0, 0);
        }
    }
}