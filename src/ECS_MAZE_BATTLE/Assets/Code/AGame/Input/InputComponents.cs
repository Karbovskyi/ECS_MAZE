using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input
{
  [Input] public class Input : IComponent { }
  [Input] public class AxisInput : IComponent { public Vector2 Value; }
  [Input] public class FirstTouch : IComponent { public Vector2 Value; }
  [Input] public class SecondTouch : IComponent { public Vector2 Value; }
}