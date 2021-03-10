using UnityEngine;

namespace Scripts.Player
{
    [CreateAssetMenu(fileName = "Newe Health points", menuName = "ScriptableObjects/HealthPoints")]
    public class HealthPoints : ScriptableObject
    {
        private int _hp;
        public int maxHp;

        public int MaxHp
        {
            get
            {
                return maxHp;
            }
        }
        public int Hp
        {
            get
            {
                return _hp;
            }
        }
        //radi kao start, awake se samo poziva kada se objekt stvara (asseti se stvaraju samo jednom i ne stvaraju se opet na restart igre)
        private void OnEnable()
        {
            _hp = maxHp;
        }

        public void ChangeHp(int n)
        {
            bool isDmg = n < 0;
            if (isDmg)
            {
                if (_hp + n <= 0)
                {
                    //TODO Death animation
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
                //TODO healing animacija
                _hp += n;
            }
            //RenderHp();
        }
        /*
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
        */
    }
}