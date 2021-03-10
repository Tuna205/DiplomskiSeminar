using Map.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Map
{
    [CreateAssetMenu(fileName = "New Obstacles", menuName = "ScriptableObjects/Obstacles")]
    public class ObstacleList : ScriptableObject
    {
        public List<IObstacle> obstacles = new List<IObstacle>();
    }
}