using System;
using System.Collections.Generic;
using Cards;
using Decks;
using ScriptableObjects;
using UnityEngine;

namespace Hands
{
    public class Hand : MonoBehaviour
    {
        public CardBack cardBack;
        public int maxCards = 5;
        
        public Deck deck;

        public Action onCardPlayed;

        private bool _canPlay = true;
        private List<BaseCard> _cards;
        private Vector3 _lastCardPosition;

        public bool CanPlayCards { get; set; }

        private static readonly Vector3 DistanceBetweenCards = new Vector3(3, 0, 0);

        public CardBack CardBack => cardBack;

        private void Awake()
        {
            _cards = new List<BaseCard>();
            CanPlayCards = _canPlay;
        }

        private void Start()
        {
            Draw(maxCards);
        }

        public void Draw(int n)
        {
            if (_cards.Count + n > maxCards)
            {
                //TODO discard cards
                print("To many cards in hand");
                return;
            }
            List<int> addedCards = deck.Draw(n);
            foreach (int cardId in addedCards)
            {
                BaseCard card = InstantiateCard(IdToCard.Instance.dict[cardId]);
                _cards.Add(card);
            }
        }

        private BaseCard InstantiateCard(BaseCard cardPrefab)
        {
            var card = Instantiate(cardPrefab, transform.position + _lastCardPosition, Quaternion.identity, transform);
            _lastCardPosition += DistanceBetweenCards;
            return card;
        }

        public void RemoveCard(BaseCard card)
        {
            if (!_cards.Contains(card)) return;
            _cards.Remove(card);
            int siblingIndex = card.transform.GetSiblingIndex();
            Destroy(card.gameObject);
            RearrangeCards(siblingIndex);
        }

        //need number of cards and card child count from hand parent
        private void RearrangeCards(int destroyedSiblingIndex)
        {
            foreach (Transform t in this.transform)
            {
                if (t.GetSiblingIndex() < destroyedSiblingIndex) continue;
                t.transform.position -= DistanceBetweenCards;
            }
            _lastCardPosition -= DistanceBetweenCards;
        }
    }
}