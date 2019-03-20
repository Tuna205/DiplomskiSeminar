using UnityEngine;
using System;
using ScriptableObjects.Managers;
using Scripts.Hand;
using Scripts.Player;

namespace Scripts.Cards{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class BaseCard : MonoBehaviour, ICloneable{

        protected Player.Player player;
        public CardData cardData;
        public abstract bool Ability();

        public abstract int Id{get;}
        protected void Init(){
            player = PlayerManager.Instance.GetComponent<Player.Player>();
            this.name = cardData.name;
            this.GetComponent<SpriteRenderer>().sprite = cardData.artwork;

            IdToCard.Instance.dict[Id] = this;
            //TODO setup collider width/height
        }
        
        public void OnMouseDown()
        {
            print("Card Hit");
            if (!Ability())
            {
                Debug.Log("Ability failed");
                return;
            }
            //TODO micanje karte iz ruke
            //RemoveCardFromHand(this.gameObject);
            //TODO pogle object pooling
            //Destroy(gameObject);
        }

        public object Clone()
        {
            return Instantiate(this.gameObject);
        }
    }
}