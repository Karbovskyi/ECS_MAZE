using Code.AAAGame.Map.MapFeature.WallsFactory;
using Code.AAAGame.Map.MapService;
using Entitas;
using Unity.Mathematics;
using UnityEngine;

namespace Code.AAAGame.Map.BuildingService.Systems
{
    public class PreviewWallPlacementSystem : IExecuteSystem
    {
        private readonly IMapService _mapService;
        private readonly IWallFactory _wallFactory;
        private readonly IGroup<GameEntity> _mapBuildLines;

        private Vector2Int _previousTouchCell;
        private Vector2Int _previousEndLine;
        
        public PreviewWallPlacementSystem(GameContext game, IMapService mapService, IWallFactory wallFactory)
        {
            _mapService = mapService;
            _wallFactory = wallFactory;
            _mapBuildLines = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Map,
                GameMatcher.BuildingMode,
                GameMatcher.BuildType,
                GameMatcher.TouchStartCell, 
                GameMatcher.TouchCurrentCell));
        }
    
        public void Execute()
        {
            foreach (GameEntity entity in _mapBuildLines)
            {
                if (entity.BuildingMode != BuildingMode.Build || entity.BuildType != BuildType.Wall)
                    continue;

                Vector2Int start = entity.TouchStartCell;
                Vector2Int end = entity.TouchCurrentCell;

                if (_previousTouchCell == end)
                    continue;
            
                _previousTouchCell = end;
            
                bool isHorizontal = Mathf.Abs(start.x - end.x) >= Mathf.Abs(start.y - end.y);
                Vector2Int endLine = isHorizontal ? new Vector2Int(end.x, start.y) : new Vector2Int(start.x, end.y);
            
                if (_previousEndLine == endLine)
                    continue;
            
                _previousEndLine = endLine;
                entity.isWallGhostUpdated = true;
            
                CreateWallLine(start, endLine, isHorizontal);
            }
        }
    
        private void CreateWallLine(Vector2Int start, Vector2Int end, bool isHorizontal)
        {
            int length = isHorizontal ? Mathf.Abs(start.x - end.x) : Mathf.Abs(start.y - end.y);
            bool isPositive = isHorizontal ? start.x < end.x : start.y < end.y;
        
            for (int i = 0; i < length; i++)
            {
                Vector2 wallPosition = isHorizontal
                    ? new Vector2(isPositive ? start.x + i + 0.5f : start.x - i - 1 + 0.5f, start.y)
                    : new Vector2(start.x, isPositive ? start.y + i + 0.5f : start.y - i - 1 + 0.5f);
            
                if (_mapService.TryAddWall(wallPosition))
                {
                    var wall = _wallFactory.CreateWall(wallPosition);
                    wall.isWallGhost = true;
                }
            }
        }
    }
}