using Code.Gameplay;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.States.GameStates
{
    public class MapLoopState : EndOfFrameExitState
    {
        private readonly ISystemFactory _systems;
        private readonly GameContext _gameContext;
        private readonly IInputService _inputService;
        private MapFeature _feature;

        public MapLoopState(ISystemFactory systems, GameContext gameContext, IInputService inputService)
        {
            _systems = systems;
            _gameContext = gameContext;
            _inputService = inputService;
        }
    
        public override void Enter()
        {
            _feature = _systems.Create<MapFeature>();
            _feature.Initialize();
            
            _inputService.ActionsControlSetActive(true);
            _inputService.MapButtonsControlSetActive(true);
        }

        protected override void OnUpdate()
        {
            _feature.Execute();
            _feature.Cleanup();
        }

        protected override void ExitOnEndOfFrame()
        {
            _feature.DeactivateReactiveSystems();
            _feature.ClearReactiveSystems();

            _inputService.ActionsControlSetActive(false);
            _inputService.MapButtonsControlSetActive(false);
            
            DestructEntities();
      
            _feature.Cleanup();
            _feature.TearDown();
            _feature = null;
        }

        private void DestructEntities()
        {
            foreach (GameEntity entity in _gameContext.GetEntities()) 
                entity.isDestructed = true;
        }
    }
}