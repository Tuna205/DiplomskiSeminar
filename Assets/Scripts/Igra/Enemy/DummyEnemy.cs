using Scripts.Player;

namespace Scripts.Cards
{
    public class DummyEnemy : BaseCharacter
    {
        void Update()
        {
            print($"Enemy hp = {this.Hp.Hp}");
        }
    }
}