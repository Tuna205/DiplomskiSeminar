using Players;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private HealthPoints _hp;
        private Slider _hpBar;

        private void Awake()
        {
            _hpBar = this.GetComponent<Slider>();
            _hpBar.maxValue = _hp.MaxHp;
            _hpBar.minValue = 0;
            _hpBar.wholeNumbers = true;
        }

        private void Start()
        {
            _hp.onHpChanged += UpdateBar;
            UpdateBar(_hp.MaxHp);
        }

        private void UpdateBar(int hpValue)
        {
            _hpBar.value = hpValue;
        }

        private void OnDestroy()
        {
            _hp.onHpChanged -= UpdateBar;
        }
    }
}