using ScriptableObjects.Cards;
using Scripts.Cards;
using Scripts.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Hand
{
    public class Hand : MonoBehaviour
    {
        public CardBack cardBack;
        //nazalost treba da karte znaju cije su
        public BaseCharacter character;
        public int maxCards = 5;

        //samo za ucitavanje!
        public bool canPlay;

        //TODO promijeni
        public Deck.Deck _deck;

        private List<int> _handIds;

        private Vector3 lastCardPosition;

        //public CardsInHand cardsInHand;
        private bool _canPlayCards;

        public bool CanPlayCards
        {
            get
            {
                return _canPlayCards;
            }

            set
            {
                _canPlayCards = value;
            }
        }

        private bool _playedCard;

        public bool PlayedCard
        {
            get
            {
                return _playedCard;
            }
            set
            {
                _playedCard = value;
            }
        }

        private void Awake()
        {
            //_hand = cardsInHand.cards;
            _handIds = new List<int>();
            _canPlayCards = canPlay;
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
            return _handIds.Count;
        }

        public void Draw(int n)
        {
            if (_handIds.Count + n > maxCards)
            {
                //TODO discard cards
                print("To many cards in hand");
                return;
            }
            List<int> addedCards = _deck.Draw(n);
            _handIds.AddRange(addedCards);
            foreach (int cardId in addedCards)
            {
                InstantiateCard(IdToCard.Instance.dict[cardId]);
            }
        }

        //Uses localCardPosition for instantiate postion
        private void InstantiateCard(BaseCard card)
        {
            //ako player nemoze igrat karte onda prikazi backside
            /*
            if(CanPlayCards == false){
                card.ShowBack();
            }
            */
            var tmp = Instantiate(card, this.transform.position + lastCardPosition, Quaternion.identity, this.transform);
            lastCardPosition += new Vector3(3, 0, 0);
        }

        public void RemoveCard(BaseCard card)
        {
            //TODO if go none in hand
            _handIds.Remove(card.Id);
            //print(_handIds.Count);
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
            lastCardPosition -= new Vector3(3, 0, 0);
        }

        private void Update()
        {
            foreach (int i in _handIds)
            {
                //print($"{this.name} {i}");
            }
            //print($"{this.gameObject.name} last position = {lastCardPosition.x}");

        }
    }
}