using System;
using UnityEngine;

namespace Players
{
    [CreateAssetMenu(fileName = "New Health points", menuName = "ScriptableObjects/HealthPoints")]
    public class HealthPoints : ScriptableObject
    {
        [SerializeField] private int _maxHp;
        private int _hp;

        public int MaxHp => _maxHp;
        public int Hp => _hp;

        public Action<int> onHpChanged;

        //radi kao start, awake se samo poziva kada se objekt stvara (asseti se stvaraju samo jednom i ne stvaraju se opet na restart igre)
        private void OnEnable()
        {
            _hp = _maxHp;
        }

        public void ChangeHp(int dmg)
        {
            bool isDmg = dmg < 0;
            if (isDmg)
            {
                if (_hp + dmg <= 0)
                {
                    //TODO Death animation
                    _hp = 0;
                }
                else
                {
                    //TODO dmg animation
                    _hp += dmg;
                }
            }
            else
            {
                //TODO healing animation
                _hp += dmg;
            }
            onHpChanged?.Invoke(_hp);
        }
    }
}