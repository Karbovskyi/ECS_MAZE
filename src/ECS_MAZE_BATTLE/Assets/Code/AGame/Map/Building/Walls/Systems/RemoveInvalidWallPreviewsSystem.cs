using Code.AAAGame.Map.MapService;
using Entitas;
using Unity.Mathematics;
using UnityEngine;

namespace Code.AAAGame.Map.BuildingService.Systems
{
    public class RemoveInvalidWallPreviewsSystem : IExecuteSystem
    {
        private readonly IMapService _mapService;
        private readonly IGroup<GameEntity> _ghostStartAndFinish;
        private readonly IGroup<GameEntity> _wallGhosts;
        
        public RemoveInvalidWallPreviewsSystem(GameContext game, IMapService mapService)
        {
            _mapService = mapService;
            _ghostStartAndFinish = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Map, 
                    GameMatcher.TouchStartCell, 
                    GameMatcher.TouchCurrentCell, 
                    GameMatcher.WallGhostUpdated));
            
            _wallGhosts = game.GetGroup(GameMatcher.WallGhost);
        }
    
        public void Execute()
        {
            foreach (var entity in _ghostStartAndFinish.GetEntities())
            {
                (bool isHorizontal, float min, float max, float fixedCoord) = GetWallBounds(entity);
            
                foreach (var ghost in _wallGhosts)
                {
                    if (!IsWallGhostOnLine(ghost, isHorizontal, min, max, fixedCoord))
                    {
                        _mapService.RemoveWall(new Vector2(ghost.WorldPosition.x, ghost.WorldPosition.z));
                        ghost.isDestructed = true;
                    }
                }
            
                entity.isWallGhostUpdated = false;
            }
        }

        private (bool isHorizontal, float min, float max, float fixedCoord) GetWallBounds(GameEntity entity)
        {
            Vector2Int start = entity.TouchStartCell;
            Vector2Int end = entity.TouchCurrentCell;
        
            if (math.abs(start.x - end.x) >= math.abs(start.y - end.y))
            {
                return (true, math.min(start.x, end.x), math.max(start.x, end.x), start.y);
            }
            else
            {
                return (false, math.min(start.y, end.y), math.max(start.y, end.y), start.x);
            }
        }

        private bool IsWallGhostOnLine(GameEntity ghost, bool isHorizontal, float min, float max, float fixedCoord)
        {
            if (isHorizontal)
            {
                return Mathf.Approximately(ghost.WorldPosition.z, fixedCoord) && ghost.WorldPosition.x >= min && ghost.WorldPosition.x <= max;
            }
            else
            {
                return Mathf.Approximately(ghost.WorldPosition.x, fixedCoord) && ghost.WorldPosition.z >= min && ghost.WorldPosition.z <= max;
            }
        }
    }
}