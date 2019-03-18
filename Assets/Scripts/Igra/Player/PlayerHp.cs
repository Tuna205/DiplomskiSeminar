using UnityEngine;

namespace Scripts.Player
{
    internal class PlayerHp : ScriptableObject
    {
        private int _hp;
        public int maxHp;

        public void ChangeHp(int n)
        {
            bool isDmg = n < 0;
            if (isDmg)
            {
                if (_hp + n <= 0)
                {
                    //Todo Death animation
                    _hp = 0;            
                }
                else
                {
                    //TODO dmg animacija
                    _hp += n;
                }
            }
            else
            {
                //Todo healing animacija
                _hp += n;
            }
            //RenderHp();
        }

        private void Init()
        {
            _hp = maxHp;
        }

        public static PlayerHp CreateInstance()
        {
            var data = ScriptableObject.CreateInstance<PlayerHp>();
            data.Init();
            return data;
        }
    }
}