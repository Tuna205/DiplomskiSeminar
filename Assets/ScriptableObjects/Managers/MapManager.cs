using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Managers
{
    public class MapManager : ScriptableObject
    {
        private static GameObject _inst;
        public static GameObject Instance
        {
            get
            {
                if (_inst == null)
                {
                    _inst = GameObject.FindGameObjectWithTag("Map");
                }
                if (_inst == null)
                {
                    throw new MissingReferenceException("Map not in scene");
                }
                return _inst;
            }
        }

        private void Awake()
        {
            Debug.Log("AWAKE");
            this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        }
    }
}

