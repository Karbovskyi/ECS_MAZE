using UnityEngine;

namespace Code.AAAGame.Map.MapService
{
    public class MapService : IMapService
    {
        private MapData _mapData;
    
        public void CreateMap(int width, int height)
        {
            if (_mapData != null)
            {
                Debug.LogError("Map Already Exists");
                return;
            }
        
            _mapData = new MapData(width, height);
        }

        public bool TryAddWall(Vector2 wallPosition)
        {
            return _mapData.TryAddWall(wallPosition);
        }

        public void RemoveWall(Vector2 wallPosition)
        {
            _mapData.RemoveWall(wallPosition);
        }

        public void MapDebug()
        {
            _mapData.MapDebug();
        }
    }
}