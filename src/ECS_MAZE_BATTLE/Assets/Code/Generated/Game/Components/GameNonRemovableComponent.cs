//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherNonRemovable;

    public static Entitas.IMatcher<GameEntity> NonRemovable {
        get {
            if (_matcherNonRemovable == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NonRemovable);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNonRemovable = matcher;
            }

            return _matcherNonRemovable;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.AAAGame.Map.NonRemovable nonRemovableComponent = new Code.AAAGame.Map.NonRemovable();

    public bool isNonRemovable {
        get { return HasComponent(GameComponentsLookup.NonRemovable); }
        set {
            if (value != isNonRemovable) {
                var index = GameComponentsLookup.NonRemovable;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : nonRemovableComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
