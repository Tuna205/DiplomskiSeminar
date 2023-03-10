using System.Collections.Generic;
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
        protected Hand _hand;
        protected BaseCharacter _character;
        [SerializeField] private CardData _cardData;
        protected GameManager _gameManager;
        
        public static readonly Dictionary<int, BaseCard> idToCard = new Dictionary<int, BaseCard>();
        public abstract bool Ability();

        public abstract int Id { get; }
        private void Init()
        {
            this.name = _cardData.name;
            idToCard[Id] = this;
        }

        private void InitCharacter()
        {
            Player player = this.transform.parent.parent.GetComponent<Player>(); //TODO kriticno
            _hand = player.Hand;
            _character = player.Character;
        }

        public virtual void Awake()
        {
            //TODO napravi singleton za gamemanager
            _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            InitCharacter();
        }

        private void Start()
        {
            if (_hand.CompareTag("EnemyHand"))
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
            if (_hand.CanPlayCards == false) return;
            _gameManager.CardQueue.Add(this);
            Play(true);
            print($"Player added {this.name}");
            //hand.PlayedCard = true;
            _hand.onCardPlayed?.Invoke();
        }

        public void Play(bool dontTriggerAbility)
        {
            if (dontTriggerAbility == false)
            {
                Ability();
            }
            _hand.RemoveCard(this);
        }

        public void ShowFront()
        {
            this.GetComponent<SpriteRenderer>().sprite = _cardData.artwork;
        }

        public void ShowBack()
        {
            this.GetComponent<SpriteRenderer>().sprite = _hand.CardBack.artwork;
        }
    }
}