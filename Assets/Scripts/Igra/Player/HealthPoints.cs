using UnityEngine;

namespace Scripts.Player
{
    public class HealthPoints : ScriptableObject
    {
        private int _hp;
        private int maxHp;

        public int Hp{
            get{
                return _hp;
            }
        }

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

        private void Init(int maxHp)
        {
            this.maxHp = maxHp;
            this._hp = maxHp;
        }

        public static HealthPoints CreateInstance(int maxHp)
        {
            var data = ScriptableObject.CreateInstance<HealthPoints>();
            data.Init(maxHp);
            return data;
        }
    }
}