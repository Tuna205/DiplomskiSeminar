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
        Hand.Hand hand;
        protected BaseCharacter character;
        public CardData cardData;
        private GameManager gameManager;
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
            //Play();
            gameManager.CardQueue.Add(this);
            print($"Player added {this.name}");
            //kazemo ruci da smo igrali kartu
            hand.PlayedCard = true;
        }

        public void Play(){
            print($"Card Hit {this.name}");
            /* karta moze fizzlat
            if (!Ability())
            {
                Debug.Log("Ability failed");
                return;
            }
            */
            Ability();
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