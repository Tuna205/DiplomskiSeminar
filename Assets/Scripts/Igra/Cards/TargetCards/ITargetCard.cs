using System.Collections;
using UnityEngine;
using Scripts.Cards;
using Scripts.Map;
using ScriptableObjects.Managers;

namespace Scripts.Cards
{
    public interface ITargetCard
    {
        void WaitForClick();

        void ActionAfterClick();
    }
}