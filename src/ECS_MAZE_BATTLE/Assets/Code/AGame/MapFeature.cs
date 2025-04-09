using Code.AAAGame.Map.BuildingService.Systems;
using Code.AAAGame.Map.MapFeature;
using Code.Common.Destruct;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Input;
using Code.Gameplay.Input.Systems;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay
{
    public class MapFeature : Feature
    {
        public MapFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<BindViewFeature>());
            
            Add(systems.Create<InitializeMapSystem>());
            Add(systems.Create<SetupMapBordersSystem>());
            
            Add(systems.Create<TrackTouchCellsSystem>());
            Add(systems.Create<ClearTouchCellsOnTouchEndSystem>());
            
            Add(systems.Create<PreviewWallPlacementSystem>());
            Add(systems.Create<RemoveInvalidWallPreviewsSystem>());
            Add(systems.Create<FinalizeWallConstructionSystem>());
            Add(systems.Create<DebugMapData>());
            Add(systems.Create<RemoveWallSystem>());
            
            Add(systems.Create<MovementFeature>());
      
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}