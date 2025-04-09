//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTouchStartCell;

    public static Entitas.IMatcher<GameEntity> TouchStartCell {
        get {
            if (_matcherTouchStartCell == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TouchStartCell);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTouchStartCell = matcher;
            }

            return _matcherTouchStartCell;
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

    public Code.AAAGame.Map.TouchStartCell touchStartCell { get { return (Code.AAAGame.Map.TouchStartCell)GetComponent(GameComponentsLookup.TouchStartCell); } }
    public UnityEngine.Vector2Int TouchStartCell { get { return touchStartCell.Value; } }
    public bool hasTouchStartCell { get { return HasComponent(GameComponentsLookup.TouchStartCell); } }

    public GameEntity AddTouchStartCell(UnityEngine.Vector2Int newValue) {
        var index = GameComponentsLookup.TouchStartCell;
        var component = (Code.AAAGame.Map.TouchStartCell)CreateComponent(index, typeof(Code.AAAGame.Map.TouchStartCell));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceTouchStartCell(UnityEngine.Vector2Int newValue) {
        var index = GameComponentsLookup.TouchStartCell;
        var component = (Code.AAAGame.Map.TouchStartCell)CreateComponent(index, typeof(Code.AAAGame.Map.TouchStartCell));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveTouchStartCell() {
        RemoveComponent(GameComponentsLookup.TouchStartCell);
        return this;
    }
}
