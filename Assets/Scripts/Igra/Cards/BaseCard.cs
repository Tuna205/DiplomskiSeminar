using UnityEngine;
using System;
using ScriptableObjects.Managers;
using Scripts.Hand;
using Scripts.Player;

namespace Scripts.Cards{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class BaseCard : MonoBehaviour{

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

        public virtual void Awake(){
            Init();
        }
        
        public void OnMouseDown()
        {
            print($"Card Hit {this.name}");
            if (!Ability())
            {
                Debug.Log("Ability failed");
                return;
            }
            Hand.Hand hand = HandManager.Instance.GetComponent<Hand.Hand>();
            hand.RemoveCard(this);
        }
    }
}