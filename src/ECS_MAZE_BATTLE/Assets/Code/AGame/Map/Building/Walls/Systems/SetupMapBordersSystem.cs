using Code.AAAGame.Map.MapFeature.WallsFactory;
using Code.AAAGame.Map.MapService;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.AAAGame.Map.BuildingService.Systems
{
    public class SetupMapBordersSystem : IInitializeSystem
    {
        private readonly GameContext _game;
        private readonly IMapService _mapService;
        private readonly IWallFactory _wallFactory;
        private readonly IStaticDataService _staticDataService;

        public SetupMapBordersSystem(GameContext game, IMapService mapService, IWallFactory wallFactory, IStaticDataService staticDataService)
        {
            _game = game;
            _mapService = mapService;
            _wallFactory = wallFactory;
            _staticDataService = staticDataService;
        }

        public void Initialize()
        {
            int Width = _staticDataService.GetMapWidth();
            int Height = _staticDataService.GetMapHeight();
            
            for (int x = 0; x < Width; x++)
            {
                var downWall = new Vector2(x + 0.5f, 0);
                CreatePerimeterWall(downWall, Vector2.zero);
                
                var upWall = new Vector2(x + 0.5f, Height);
                CreatePerimeterWall(upWall, new Vector2(0, -0.4f));
            }

            for (int y = 0; y < Height; y++)
            {
                var leftWall = new Vector2(0, y + 0.5f);
                CreatePerimeterWall(leftWall, Vector2.zero);
                
                var rightWall = new Vector2(Width, y + 0.5f);
                CreatePerimeterWall(rightWall, new Vector2(-0.4f, 0));
            }
        }

        private void CreatePerimeterWall(Vector2 position, Vector2 fix)
        {
            // fix - зсув позиції, Це треба, бо інакше вийдемо за рамки масиву клітинок при спробі поставити стіну в цю позицію
            
            GameEntity wall = _wallFactory.CreateWall(position);
            position += fix;
            _mapService.TryAddWall(position);
            wall.isNonRemovable = true;
        }
    }
}