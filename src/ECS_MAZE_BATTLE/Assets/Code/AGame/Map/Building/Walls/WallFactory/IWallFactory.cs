using UnityEngine;

namespace Code.AAAGame.Map.MapFeature.WallsFactory
{
    public interface IWallFactory
    {
        GameEntity CreateWall(Vector2 position);
    }
}