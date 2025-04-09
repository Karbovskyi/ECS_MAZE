using UnityEngine;

namespace Code.AAAGame.Map.MapService
{
    public interface IMapService
    {
        public void CreateMap(int width, int height);
        public bool TryAddWall(Vector2 wallPosition);
        public void RemoveWall(Vector2 wallPosition);
        void MapDebug();
    }
}