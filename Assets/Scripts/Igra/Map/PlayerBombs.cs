using Map.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Map
{
    [CreateAssetMenu(fileName = "New Player bombs", menuName = "ScriptableObjects/Player bombs")]
    public class PlayerBombs : ScriptableObject
    {
        public List<IBomb> bombs = new List<IBomb>();
    }
}