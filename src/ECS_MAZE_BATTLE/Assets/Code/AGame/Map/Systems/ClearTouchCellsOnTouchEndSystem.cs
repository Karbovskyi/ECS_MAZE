using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class ClearTouchCellsOnTouchEndSystem : ICleanupSystem
    {
        private readonly IGroup<InputEntity> _inputs;
        private readonly IGroup<GameEntity> _maps;

        public ClearTouchCellsOnTouchEndSystem(InputContext input, GameContext game)
        {
            _inputs = input.GetGroup(InputMatcher.Input);
            _maps = game.GetGroup(GameMatcher.Map);
        }
    
        public void Cleanup()
        {
            foreach (InputEntity input in _inputs)
            foreach (GameEntity map in _maps)
            {
                if (input.hasFirstTouch)
                    return;

                if (map.hasTouchStartCell)
                {
                    map.RemoveTouchStartCell();
                }
                
                if (map.hasTouchCurrentCell)
                {
                    map.RemoveTouchCurrentCell();
                }
            }
        }
    }
}