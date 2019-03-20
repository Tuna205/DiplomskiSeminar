using System.Collections.Generic;
using UnityEngine;
using Scripts.Map;
using Map.Interfaces;

namespace Scripts.Map
{
    [CreateAssetMenu(fileName = "New Player bombs", menuName = "ScriptableObjects/Player bombs")]
    public class PlayerBombs : ScriptableObject
    {
        public List<IBomb> bombs = new List<IBomb>();
    }
}