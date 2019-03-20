using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Scripts.Deck;
using Scripts.Cards;

namespace Scripts.Deck
{
    public class Deck : MonoBehaviour
    {
        public DeckList deckList;
        private List<int> _deck;

        private void Init(){
            _deck = new List<int>();
            deckList.startDeckList.ForEach(card =>
            {
                _deck.Add(card.Id);
            });
            Shuffle(); 
        }

        private void Start(){
            //TODO incijaliziraj deck s deckList
            
        }

        //zovi samo iz Hand.Draw
        public List<BaseCard> Draw(int n)
        {
            List<BaseCard> cardsDrawn = new List<BaseCard>();
            if (n > _deck.Count)
            {
                print("Not enough cards in deck");
                return Draw(_deck.Count);
            }

            for (int i = 0; i < n; i++)
            {
                cardsDrawn.Add(IdToCard.Instance.dict[_deck[i]]);
            }
            for (int i = 0; i < n; i++)
            {
                _deck.RemoveAt(0);
            }

            return cardsDrawn;
        }

        public void Shuffle()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = _deck.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                int value = _deck[k];
                _deck[k] = _deck[n];
                _deck[n] = value;
            }
        }

        public void Add(int cardId)
        {
            _deck.Add(cardId);
            Shuffle();
        }

        public void Remove(int cardId)
        {
            _deck.Remove(cardId);
            Shuffle();
        }

        // TODO mozda na ekran prikazati sve karte
        public List<BaseCard> ShowDeck()
        {
            throw new NotImplementedException();
        }

        void Awake()
        {
            Init();
        }
        /*
        public void DeepCopy(List<BaseCard> from, List<BaseCard> to)
        {
            to = new List<BaseCard>(from.Count);
            from.ForEach((item) =>
            {
                to.Add(item.Clone() as BaseCard);
            });
        }
        */
    }
}

        