using System.Collections.Generic;
using UnityEngine;
using Scripts.Map;

namespace Scripts.Map
{
    [CreateAssetMenu(fileName = "New Character position", menuName = "ScriptableObjects/Character position")]
    public class CharacterPosition : ScriptableObject {
        [HideInInspector]
        public Tile tile;

        
        [HideInInspector]
        public GameObject character;
    }
}