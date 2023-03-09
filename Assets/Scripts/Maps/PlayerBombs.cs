using System.Collections.Generic;
using Maps.Interfaces;
using UnityEngine;

namespace Maps
{
    [CreateAssetMenu(fileName = "New Player bombs", menuName = "ScriptableObjects/Player bombs")]
    public class PlayerBombs : ScriptableObject
    {
        public List<IBomb> bombs = new List<IBomb>();
    }
}