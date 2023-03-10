using Maps;
using UnityEngine;

namespace ScriptableObjects.Managers
{
    public class MapManager //TODO generic Manager
    {
        private static Map _inst;
        public static Map Instance
        {
            get
            {
                if (_inst != null) return _inst;
                GameObject mapGo = GameObject.FindGameObjectWithTag("Map");
                _inst = mapGo != null ? mapGo.GetComponent<Map>() : null;
                return _inst;
            }
        }
    }
}

