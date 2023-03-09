using Players;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HpBar : MonoBehaviour
    {
        public HealthPoints hp;
        private Slider _hpBar;

        private void Awake()
        {
            _hpBar = this.GetComponent<Slider>();
            _hpBar.maxValue = hp.MaxHp;
            _hpBar.minValue = 0;
            _hpBar.wholeNumbers = true;
        }

        private void Start()
        {
            hp.onHpChanged += UpdateBar;
            UpdateBar(hp.maxHp);
        }

        private void UpdateBar(int hpValue)
        {
            _hpBar.value = hpValue;
        }

        private void OnDestroy()
        {
            hp.onHpChanged -= UpdateBar;
        }
    }
}