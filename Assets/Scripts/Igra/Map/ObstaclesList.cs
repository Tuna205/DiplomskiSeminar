using System.Collections.Generic;
using UnityEngine;
using Scripts.Map;
using Map.Interfaces;

namespace Scripts.Map
{
    [CreateAssetMenu(fileName = "New Obstacles", menuName = "ScriptableObjects/Obstacles")]
    public class ObstacleList : ScriptableObject
    {
        public List<IObstacle> obstacles = new List<IObstacle>();
    }
}