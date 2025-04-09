using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
    public class LoadingMapState : SimplePayloadState<string>
    {
        
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadingMapState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
    
        public override void Enter(string sceneName)
        {
            _sceneLoader.LoadScene(sceneName, EnterMapLoopState);
        }

        private void EnterMapLoopState()
        {
            _stateMachine.Enter<MapEnterState>();
        }
    }
}