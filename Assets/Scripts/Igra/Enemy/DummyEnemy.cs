using System.Collections;
using UnityEngine;
using Scripts.Player;
using Scripts.Map;
using ScriptableObjects.Managers;

namespace Scripts.Cards
{
    public class DummyEnemy : BaseCharacter
    {
        void Update(){
            print($"Enemy hp = {this.Hp.Hp}");
        }
    }
}