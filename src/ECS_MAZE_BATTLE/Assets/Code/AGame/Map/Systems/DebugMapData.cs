using Code.AAAGame.Map.MapService;
using Entitas;

namespace Code.AAAGame.Map.MapFeature
{
    public class DebugMapData : IExecuteSystem
    {
        private readonly IMapService _mapService;
        private readonly IGroup<GameEntity> _maps;

        public DebugMapData(GameContext game, IMapService mapService)
        {
            _mapService = mapService;
            _maps = game.GetGroup(GameMatcher.Map);
        }
    
        public void Execute()
        {
            foreach (GameEntity map in _maps)
            {
                _mapService.MapDebug();
            }
        }
    }
}