using UnityEngine;

namespace Code.AAAGame.Map.MapService
{
    public static class MapExtensions
    {
        public static Vector2Int GetCellSide(Vector2 mapPosition)
        {
            float distanceToLeft = mapPosition.x - Mathf.Floor(mapPosition.x);
            float distanceToRight = (Mathf.Floor(mapPosition.x)+1) - mapPosition.x;
            float distanceToDown = mapPosition.y - Mathf.Floor(mapPosition.y);
            float distanceToUp = (Mathf.Floor(mapPosition.y)+1) - mapPosition.y;
        
            float min = Mathf.Min(distanceToLeft, distanceToRight, distanceToDown,distanceToUp);

            if (Mathf.Approximately(distanceToLeft, min))
            {
                return Vector2Int.left;
            }

            if (Mathf.Approximately(distanceToRight, min))
            {
                return Vector2Int.right;
            }

            if (Mathf.Approximately(distanceToDown, min))
            {
                return Vector2Int.down;
            }

            if (Mathf.Approximately(distanceToUp, min))
            {
                return Vector2Int.up;
            }

            return Vector2Int.zero;
        }

        public static Vector2 GetWallPosition(Vector2 mapPosition)
        {
            Vector2Int side = GetCellSide(mapPosition);

            if (side == Vector2Int.left)
            {
                return new Vector2(Mathf.FloorToInt(mapPosition.x), Mathf.FloorToInt(mapPosition.y) + 0.5f);
            }
        
            if (side == Vector2Int.right)
            {
                return new Vector2(Mathf.FloorToInt(mapPosition.x)+1, Mathf.FloorToInt(mapPosition.y) + 0.5f);
            }
        
            if (side == Vector2Int.down)
            {
                return new Vector2(Mathf.FloorToInt(mapPosition.x) + 0.5f, Mathf.FloorToInt(mapPosition.y));
            }
        
            if (side == Vector2Int.up)
            {
                return new Vector2(Mathf.FloorToInt(mapPosition.x) + 0.5f, Mathf.FloorToInt(mapPosition.y)+1);
            }
        
            return Vector2.zero;
        }
    
        public static Vector2Int GetCellPosition(Vector3 mapPosition, int width, int height)
        {
            return new Vector2Int(
                Mathf.Clamp(Mathf.RoundToInt(mapPosition.x), 0, width),
                Mathf.Clamp(Mathf.RoundToInt(mapPosition.z), 0, height));
        }
    }
}