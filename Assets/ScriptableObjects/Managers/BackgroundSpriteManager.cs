using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Managers
{
    [CreateAssetMenu(fileName = "New Background Sprites", menuName = "Background Sprites")]
    public class BackgroundSpriteManager : ScriptableObject{
        public Sprite topRight;
        public Sprite topCenter;
        public Sprite topLeft;
        public Sprite bottomLeft;
        public Sprite bottomRight;
        public Sprite bottomCenter;
        public Sprite left;
        public Sprite right;
        //mozda imati listu za centar
        public Sprite center;
    }
}