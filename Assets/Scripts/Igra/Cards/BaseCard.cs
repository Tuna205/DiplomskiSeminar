using Scripts.GM;
using Scripts.LevelObjects;
using UnityEngine;

namespace Scripts.Cards
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class BaseCard : MonoBehaviour
    {
        protected Hand.Hand hand;
        protected BaseCharacter character;
        public CardData cardData;
        protected GameManager gameManager;
        public abstract bool Ability();

        public abstract int Id { get; }
        protected void Init()
        {
            this.name = cardData.name;
            IdToCard.Instance.dict[Id] = this;
            //TODO setup collider width/height
        }

        private void InitCharacter()
        {
            hand = this.transform.parent.GetComponent<Hand.Hand>();
            character = hand.character;
        }

        public virtual void Awake()
        {
            //TODO napravi singleton za gamemanager
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            InitCharacter();
        }

        private void Start()
        {
            if (hand.CompareTag("EnemyHand"))
            {
                ShowBack();
            }
            else
            {
                ShowFront();
            }
        }

        private void OnValidate()
        {
            //HACK validate se izvodi kad se doda karta u deck list
            Init();
        }

        public virtual void OnMouseDown()
        {
            if (hand.CanPlayCards == false) return;
            gameManager.CardQueue.Add(this);
            Play(true);
            print($"Player added {this.name}");
            hand.PlayedCard = true;
        }

        public void Play(bool dontTriggerAbility)
        {
            if (dontTriggerAbility == false)
            {
                Ability();
            }
            hand.RemoveCard(this);
        }

        public void ShowFront()
        {
            this.GetComponent<SpriteRenderer>().sprite = cardData.artwork;
        }

        public void ShowBack()
        {
            this.GetComponent<SpriteRenderer>().sprite = hand.CardBack.artwork;
        }
    }
}