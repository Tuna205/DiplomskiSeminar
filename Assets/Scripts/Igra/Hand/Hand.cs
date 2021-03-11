using ScriptableObjects.Cards;
using Scripts.Cards;
using Scripts.LevelObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Hand
{
    public class Hand : MonoBehaviour
    {
        public CardBack cardBack;
        public BaseCharacter character;
        public int maxCards = 5;
        //samo za ucitavanje!
        public bool canPlay;
        public Deck.Deck _deck;

        private List<BaseCard> _cards;
        private Vector3 _lastCardPosition;

        public bool CanPlayCards { get; set; }
        public bool PlayedCard { get; set; }
        public CardBack CardBack => cardBack;

        private void Awake()
        {
            //_hand = cardsInHand.cards;
            _cards = new List<BaseCard>();
            CanPlayCards = canPlay;
        }

        private void Start()
        {
            //lastCardPosition = Vector3.zero;
            Draw(maxCards);
        }

        private void ShowCardBackSide()
        {
            this.GetComponent<SpriteRenderer>().sprite = cardBack.artwork;
        }

        public int NumOfCards()
        {
            return _cards.Count;
        }

        public void Draw(int n)
        {
            if (_cards.Count + n > maxCards)
            {
                //TODO discard cards
                print("To many cards in hand");
                return;
            }
            List<int> addedCards = _deck.Draw(n);
            foreach (int cardId in addedCards)
            {
                BaseCard card = InstantiateCard(IdToCard.Instance.dict[cardId]);
                _cards.Add(card);
            }
        }

        private BaseCard InstantiateCard(BaseCard cardPrefab)
        {
            var card = Instantiate(cardPrefab, this.transform.position + _lastCardPosition, Quaternion.identity, this.transform);
            _lastCardPosition += new Vector3(3, 0, 0);
            return card;
        }

        public void RemoveCard(BaseCard card)
        {
            if (!_cards.Contains(card)) return;
            _cards.Remove(card);
            int siblingIndex = card.transform.GetSiblingIndex();
            Destroy(card.gameObject);
            RearangeCards(siblingIndex);
        }

        //need number of cards and card child count from hand parent
        private void RearangeCards(int destroyedSiblingIndex)
        {
            foreach (Transform t in this.transform)
            {
                if (t.GetSiblingIndex() < destroyedSiblingIndex) continue;
                t.transform.position -= new Vector3(3, 0, 0);
            }
            _lastCardPosition -= new Vector3(3, 0, 0);
        }

        //private void Update()
        //{
        //    foreach (int i in _handIds)
        //    {
        //        //print($"{this.name} {i}");
        //    }
        //    //print($"{this.gameObject.name} last position = {lastCardPosition.x}");

        //}
    }
}