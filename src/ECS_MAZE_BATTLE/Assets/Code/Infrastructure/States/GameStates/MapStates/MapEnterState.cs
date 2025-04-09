using Code.AAAGame.Map.MapService;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.States.GameStates
{
    public class MapEnterState : SimpleState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IMapService _mapService;
        private readonly ISystemFactory _systems;
        private readonly GameContext _gameContext;

        public MapEnterState(
            IGameStateMachine stateMachine, 
            IMapService mapService)
        {
            _stateMachine = stateMachine;
            _mapService = mapService;
        }
    
        public override void Enter()
        {
            CreateMap();
      
            _stateMachine.Enter<MapLoopState>();
        }

        private void CreateMap()
        {
            _mapService.CreateMap(20, 10);
        }
    }
}