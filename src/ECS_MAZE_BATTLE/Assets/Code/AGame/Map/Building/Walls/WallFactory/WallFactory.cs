using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.AAAGame.Map.MapFeature.WallsFactory
{
    public class WallFactory : IWallFactory
    {
        private readonly IIdentifierService _identifiers;
        
        public WallFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }
        
        public GameEntity CreateWall(Vector2 position)
        {
            Vector2Int direction = Vector2Int.right;
            
            if (Mathf.Approximately(position.x, Mathf.FloorToInt(position.x)))
            {
                direction = Vector2Int.up;
            }
            
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .With(x=>x.isWall = true)
                .AddDirection(direction)
                .AddViewPath("Wall")
                .AddWorldPosition(new Vector3(position.x, 0, position.y))
                .With(x => x.isRotationAlignedAlongDirection = true);
        }
    }
}