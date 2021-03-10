using UnityEngine;

namespace ScriptableObjects.Managers
{
    public class PlayerManager : ScriptableObject
    {
        private static GameObject _inst;
        public static GameObject Instance
        {
            get
            {
                if (_inst == null)
                {
                    _inst = GameObject.FindGameObjectWithTag("Player");
                }
                if (_inst == null)
                {
                    //throw new MissingReferenceException("Player not in scene");
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

