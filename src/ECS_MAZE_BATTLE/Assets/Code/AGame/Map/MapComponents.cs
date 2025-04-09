using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.AAAGame.Map
{
    [Game] public class TouchStartCell : IComponent { public Vector2Int Value; }
    [Game] public class TouchCurrentCell : IComponent { public Vector2Int Value; }
    [Game] public class Map : IComponent {  }
    
    [Game] public class Wall : IComponent { }
    [Game] public class WallGhost : IComponent { }
    [Game] public class WallGhostUpdated : IComponent { }
    
    
    [Game] public class BuildingModeComponent : IComponent { public BuildingMode Value; }
    [Game] public class BuildTypeComponent : IComponent { public BuildType Value; }
    [Game] public class NonRemovable : IComponent { }
    
    
}