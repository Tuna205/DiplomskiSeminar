using GameManagers;

namespace Players
{
    public class HumanPlayer : Player
    {
        private void Start()
        {
            GameManager.onPlayerTurnStart += ActivateCards;
            GameManager.onPlayerTurnEnd += DisableCards;
            GameManager.onResolveEnd += DrawCards;
        }

        private void ActivateCards()
        {
            _hand.CanPlayCards = true;
        }

        private void DisableCards()
        {
            _hand.CanPlayCards = false;
        }

        private void DrawCards()
        {
            _hand.Draw(GameManager._numCardsToPlay);
        }

        private void OnDestroy()
        {
            GameManager.onPlayerTurnStart -= ActivateCards;
            GameManager.onPlayerTurnEnd -= DisableCards;
            GameManager.onResolveEnd -= DrawCards;
        }
    }
}
