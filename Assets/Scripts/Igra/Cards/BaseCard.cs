using UnityEngine;
using System;
using ScriptableObjects.Managers;
using Scripts.Hand;
using Scripts.Player;

namespace Scripts.Cards{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class BaseCard : MonoBehaviour{

        //protected Player.Player player;
        Hand.Hand hand;
        protected BaseCharacter character;
        public CardData cardData;
        public abstract bool Ability();

        public abstract int Id{get;}
        protected void Init(){
            //player = PlayerManager.Instance.GetComponent<Player.Player>();
            
            this.name = cardData.name;

            IdToCard.Instance.dict[Id] = this;
            //TODO setup collider width/height
        }
        
        protected void InitCharacter(){
            hand = this.transform.parent.GetComponent<Hand.Hand>();

            character = hand.character;

        }

        public virtual void Awake(){
            Init();
            InitCharacter();
        }

        private void Start()
        {
            /*
            if (hand.CanPlayCards == false){
                ShowBack();
            }
            else{
                ShowFront();
            }
            */
            ShowFront();
        }

        private void OnValidate()
        {
            //HACK problem jer se validate izvoid za ucitavanja u decklist kad jos nemamo parenta
            Init();
        }
        
        public void OnMouseDown()
        {
            //Hand.Hand hand = this.transform.parent.GetComponent<Hand.Hand>();
            if (hand.CanPlayCards == false) return;
            Play();
        }

        public void Play(){
            print($"Card Hit {this.name}");
            if (!Ability())
            {
                Debug.Log("Ability failed");
                return;
            }
            hand.RemoveCard(this);
        }

        public void ShowFront(){
            this.GetComponent<SpriteRenderer>().sprite = cardData.artwork;
        }

        public void ShowBack(){
            this.GetComponent<SpriteRenderer>().sprite = cardData.cardBack.artwork;
        }
    }
}