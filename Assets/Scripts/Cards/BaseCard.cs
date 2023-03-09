using Characters;
using GameManagers;
using Hands;
using Players;
using UnityEngine;

namespace Cards
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class BaseCard : MonoBehaviour
    {
        protected Hand hand;
        protected BaseCharacter character;
        public CardData cardData;
        protected GameManager gameManager;
        public abstract bool Ability();

        public abstract int Id { get; }
        private void Init()
        {
            this.name = cardData.name;
            IdToCard.Instance.dict[Id] = this;
        }

        private void InitCharacter()
        {
            Player player = this.transform.parent.parent.GetComponent<Player>(); //TODO kriticno
            hand = player.hand;
            character = player.character;
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
            //hand.PlayedCard = true;
            hand.onCardPlayed?.Invoke();
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