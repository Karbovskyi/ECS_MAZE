using Code.AAAGame.Map;
using Code.Common.Entity;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class InitializeMapSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .AddBuildType(BuildType.Wall)
                .AddBuildingMode(BuildingMode.Build)
                .isMap = true;
        }
    }
}