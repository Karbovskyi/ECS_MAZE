//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSpriteRenderer;

    public static Entitas.IMatcher<GameEntity> SpriteRenderer {
        get {
            if (_matcherSpriteRenderer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SpriteRenderer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpriteRenderer = matcher;
            }

            return _matcherSpriteRenderer;
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

    public Code.Common.SpriteRendererComponent spriteRenderer { get { return (Code.Common.SpriteRendererComponent)GetComponent(GameComponentsLookup.SpriteRenderer); } }
    public UnityEngine.SpriteRenderer SpriteRenderer { get { return spriteRenderer.Value; } }
    public bool hasSpriteRenderer { get { return HasComponent(GameComponentsLookup.SpriteRenderer); } }

    public GameEntity AddSpriteRenderer(UnityEngine.SpriteRenderer newValue) {
        var index = GameComponentsLookup.SpriteRenderer;
        var component = (Code.Common.SpriteRendererComponent)CreateComponent(index, typeof(Code.Common.SpriteRendererComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceSpriteRenderer(UnityEngine.SpriteRenderer newValue) {
        var index = GameComponentsLookup.SpriteRenderer;
        var component = (Code.Common.SpriteRendererComponent)CreateComponent(index, typeof(Code.Common.SpriteRendererComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveSpriteRenderer() {
        RemoveComponent(GameComponentsLookup.SpriteRenderer);
        return this;
    }
}
