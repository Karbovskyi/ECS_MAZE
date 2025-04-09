using System.Collections.Generic;
using Entitas;

namespace Code.AAAGame.Map.BuildingService.Systems
{
    public class FinalizeWallConstructionSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _ghosts;
        private readonly List<GameEntity> _buffer = new (16);

        public FinalizeWallConstructionSystem(GameContext game) : base(game)
        {
            _ghosts = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.WallGhost));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(
                GameMatcher.TouchStartCell.Removed());

        protected override bool Filter(GameEntity entity) => true;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            foreach (GameEntity ghost in _ghosts.GetEntities(_buffer))
                ghost.isWallGhost = false;
        }
    }
}