using Characters;
using Decks;
using Hands;
using UnityEngine;

namespace Players
{
    public class Player : MonoBehaviour
    {
        [SerializeField] protected BaseCharacter _character;
        [SerializeField] protected Hand _hand;
        [SerializeField] protected Deck _deck;
        
        public BaseCharacter Character => _character;
        public Hand Hand => _hand;
        public Deck Deck => _deck;
    }
}
