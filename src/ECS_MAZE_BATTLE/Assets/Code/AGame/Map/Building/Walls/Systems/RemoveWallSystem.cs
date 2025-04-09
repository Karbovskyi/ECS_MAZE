using Code.AAAGame.Map.MapService;
using Entitas;
using UnityEngine;
using UnityEngine.Animations;

namespace Code.AAAGame.Map.BuildingService.Systems
{
    public class RemoveWallSystem : IExecuteSystem
    {
        private readonly InputContext _input;
        private readonly IMapService _mapService;
        private readonly ICameraService _cameraService;
        private readonly IGroup<GameEntity> _mapBuildLines;
        
        private Vector2 _previousWallPosition;
        private Vector2Int _previousEndLine;
        private readonly IGroup<InputEntity> _firstTouch;
        private readonly IGroup<GameEntity> _walls;

        public RemoveWallSystem(GameContext game, InputContext input, IMapService mapService, ICameraService cameraService)
        {
            _input = input;
            _mapService = mapService;
            _cameraService = cameraService;
            _mapBuildLines = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Map,
                GameMatcher.BuildingMode,
                GameMatcher.BuildType));
            _firstTouch = input.GetGroup(InputMatcher.FirstTouch);
            _walls = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Wall)
                .NoneOf(GameMatcher.NonRemovable));
        }
    
        public void Execute()
        {
            foreach (InputEntity touch in _firstTouch)
            foreach (GameEntity entity in _mapBuildLines)
            {
                if(entity.BuildingMode != BuildingMode.Erase || entity.BuildType != BuildType.Wall )
                    continue;
                
                
                Vector3 mapPosition = _cameraService.MainCamera.ScreenToWorldPoint(new Vector3(touch.FirstTouch.x, touch.FirstTouch.y, _cameraService.MainCamera.transform.position.y));
                Vector2 wallPosition = GetWallPosition(mapPosition);
                
                
                if (_previousWallPosition == wallPosition)
                    continue;
                
                _previousWallPosition = wallPosition;
                
                
                foreach (GameEntity wall in _walls)
                {
                    if (Mathf.Approximately(wall.WorldPosition.x, wallPosition.x) &&
                        Mathf.Approximately(wall.WorldPosition.z, wallPosition.y))
                    {
                        wall.isDestructed = true;
                        _mapService.RemoveWall(wallPosition);
                    }
                }
            }
        }

        private Vector2 GetWallPosition(Vector3 mapPosition)
        {
            return MapExtensions.GetWallPosition(new Vector2(mapPosition.x, mapPosition.z));
        }
    }
}