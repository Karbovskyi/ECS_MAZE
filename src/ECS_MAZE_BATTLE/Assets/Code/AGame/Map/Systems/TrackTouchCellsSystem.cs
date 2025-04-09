using Code.AAAGame.Map.MapService;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class TrackTouchCellsSystem : IExecuteSystem
    {
        private readonly ICameraService _cameraService;
        private readonly IStaticDataService _staticDataService;
        private readonly IGroup<InputEntity> _firstTouch;
        private readonly IGroup<GameEntity> _maps;
        
        public TrackTouchCellsSystem(InputContext input, GameContext game, ICameraService cameraService, IStaticDataService staticDataService)
        {
            _cameraService = cameraService;
            _staticDataService = staticDataService;
            _firstTouch = input.GetGroup(InputMatcher.FirstTouch);
            _maps = game.GetGroup(GameMatcher.Map);
        }
    
        public void Execute()
        {
            foreach (InputEntity touch in _firstTouch)
            foreach (GameEntity map in _maps)
            {
                Vector3 mapPosition = _cameraService.MainCamera.ScreenToWorldPoint(new Vector3(touch.FirstTouch.x, touch.FirstTouch.y, _cameraService.MainCamera.transform.position.y));
                Vector2Int cellPosition = MapExtensions.GetCellPosition(mapPosition, _staticDataService.GetMapWidth(), _staticDataService.GetMapHeight());
                
                if (!map.hasTouchStartCell) 
                    map.AddTouchStartCell(cellPosition);
                
                map.ReplaceTouchCurrentCell(cellPosition);
            }
        }
    }
}