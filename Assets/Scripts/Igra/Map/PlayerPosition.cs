using System.Collections.Generic;
using UnityEngine;
using Scripts.Map;

namespace Scripts.Map
{
    [CreateAssetMenu(fileName = "New Player position", menuName = "ScriptableObjects/Player position")]
    public class PlayerPosition : ScriptableObject {
        public Tile tile;
    }
}