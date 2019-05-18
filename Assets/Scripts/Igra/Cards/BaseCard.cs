using UnityEngine;
using System;
using ScriptableObjects.Managers;
using Scripts.Hand;
using Scripts.Player;
using Scripts.GM;

namespace Scripts.Cards{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class BaseCard : MonoBehaviour{

        //protected Player.Player player;
        protected Hand.Hand hand;
        protected BaseCharacter character;
        public CardData cardData;
        protected GameManager gameManager;
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
            //TODO napravi singleton za gamemanager
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            Init();
            InitCharacter();
        }

        private void Start()
        {
            //TODO mozda bolje s tagom enemy
            
            if (hand.CompareTag("EnemyHand")){
                ShowBack();
            }
            else{
                ShowFront();
            }
            
            //ShowFront();
        }

        private void OnValidate()
        {
            //HACK problem jer se validate izvoid za ucitavanja u decklist kad jos nemamo parenta
            Init();
        }
        
        public virtual void OnMouseDown()
        {
            //Hand.Hand hand = this.transform.parent.GetComponent<Hand.Hand>();
            if (hand.CanPlayCards == false) return;  
            gameManager.CardQueue.Add(this);
            Play(true);
            print($"Player added {this.name}");
            //kazemo ruci da smo igrali kartu
            hand.PlayedCard = true;
        }

        public void Play(bool dontTriggerAbility){
            /* karta moze fizzlat
            if (!Ability())
            {
                Debug.Log("Ability failed");
                return;
            }
            */
            if(dontTriggerAbility == false){
                Ability();
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