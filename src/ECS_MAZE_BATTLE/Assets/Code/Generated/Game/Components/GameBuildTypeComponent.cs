//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherBuildType;

    public static Entitas.IMatcher<GameEntity> BuildType {
        get {
            if (_matcherBuildType == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BuildType);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBuildType = matcher;
            }

            return _matcherBuildType;
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

    public Code.AAAGame.Map.BuildTypeComponent buildType { get { return (Code.AAAGame.Map.BuildTypeComponent)GetComponent(GameComponentsLookup.BuildType); } }
    public Code.AAAGame.Map.BuildType BuildType { get { return buildType.Value; } }
    public bool hasBuildType { get { return HasComponent(GameComponentsLookup.BuildType); } }

    public GameEntity AddBuildType(Code.AAAGame.Map.BuildType newValue) {
        var index = GameComponentsLookup.BuildType;
        var component = (Code.AAAGame.Map.BuildTypeComponent)CreateComponent(index, typeof(Code.AAAGame.Map.BuildTypeComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceBuildType(Code.AAAGame.Map.BuildType newValue) {
        var index = GameComponentsLookup.BuildType;
        var component = (Code.AAAGame.Map.BuildTypeComponent)CreateComponent(index, typeof(Code.AAAGame.Map.BuildTypeComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveBuildType() {
        RemoveComponent(GameComponentsLookup.BuildType);
        return this;
    }
}
