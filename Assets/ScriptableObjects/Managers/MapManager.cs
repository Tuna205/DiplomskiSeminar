using UnityEngine;

namespace Scripts.Map
{
    public class MapManager //TODO generic Manager
    {
        private static Map _inst;
        public static Map Instance
        {
            get
            {
                if (_inst == null)
                {
                    GameObject mapGo = GameObject.FindGameObjectWithTag("Map");
                    _inst = mapGo?.GetComponent<Map>();
                }
                return _inst;
            }
        }
    }
}

