using Code.Infrastructure.View;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.Common
{
  [Game] public class Destructed : IComponent { }
  [Game] public class View : IComponent { public IEntityView Value; }
  [Game] public class ViewPath : IComponent { public string Value; }
  [Game] public class ViewPrefab : IComponent { public EntityBehaviour Value; }
  [Game] public class SelfDestructTimer : IComponent { public float Value; }
  
  
  [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
  [Game] public class EntityLink : IComponent { [EntityIndex] public int Value; }
  
  [Game] public class WorldPosition : IComponent { public Vector3 Value; }
  
  [Game] public class Damage : IComponent { public float Value; }
  [Game] public class Active : IComponent { }
 
  [Game] public class TransformComponent : IComponent { public Transform Value; }
  [Game] public class SpriteRendererComponent : IComponent { public SpriteRenderer Value; }
}