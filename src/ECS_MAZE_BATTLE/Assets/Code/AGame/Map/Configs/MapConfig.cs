using UnityEngine;

namespace Code.Gameplay
{
    [CreateAssetMenu(fileName = "MapConfig", menuName = "Game/MapConfig")]
    public class MapConfig : ScriptableObject
    {
        [Range(5, 20)] 
        public int Width = 20;

        [Range(5, 20)] 
        public int Height = 10;
    }
}