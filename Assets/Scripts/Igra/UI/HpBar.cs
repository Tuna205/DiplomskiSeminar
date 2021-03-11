using Scripts.LevelObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    public class HpBar : MonoBehaviour
    {
        public HealthPoints hp;
        private Slider hpbar;

        void Awake()
        {
            hpbar = this.GetComponent<Slider>();
            hpbar.maxValue = hp.MaxHp;
            hpbar.minValue = 0;
            hpbar.wholeNumbers = true;
        }

        private void Start()
        {
            hp.onHpChanged += UpdateBar;
            UpdateBar(hp.maxHp);
        }

        void UpdateBar(int hpValue)
        {
            hpbar.value = hpValue;
        }

        private void OnDestroy()
        {
            hp.onHpChanged -= UpdateBar;
        }
    }
}