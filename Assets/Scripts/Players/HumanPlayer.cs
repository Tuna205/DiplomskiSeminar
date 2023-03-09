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
            hand.CanPlayCards = true;
        }

        private void DisableCards()
        {
            hand.CanPlayCards = false;
        }

        private void DrawCards()
        {
            hand.Draw(GameManager.numCardsToPlay);
        }

        private void OnDestroy()
        {
            GameManager.onPlayerTurnStart -= ActivateCards;
            GameManager.onPlayerTurnEnd -= DisableCards;
            GameManager.onResolveEnd -= DrawCards;
        }
    }
}
