using UnityEngine;

namespace ScriptableObjects.Managers
{
    [CreateAssetMenu(fileName = "New Background Sprites", menuName = "ScriptableObjects/Background Sprites")]
    public class BackgroundSpriteManager : ScriptableObject
    {
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