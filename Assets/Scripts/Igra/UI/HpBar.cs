using Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI{
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

        //UI slider value se rendera samo na change valuea  
        void Update(){
            hpbar.value = hp.Hp;
        }
        



    }
}