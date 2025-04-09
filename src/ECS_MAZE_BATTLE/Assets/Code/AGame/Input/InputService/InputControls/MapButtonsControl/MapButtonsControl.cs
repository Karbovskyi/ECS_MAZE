using Code.AAAGame.Map;
using Entitas;
using UnityEngine.InputSystem;

public class MapButtonsControl : IMapButtonsControl
{
    private readonly InputActions _inputActions;
    private readonly IGroup<GameEntity> _maps;

    public MapButtonsControl(InputActions inputActions, GameContext gameContext)
    {
        _inputActions = inputActions;
        _maps = gameContext.GetGroup(GameMatcher.Map);
    }
    
    public void SetActive(bool active)
    {
        if (active)
        {
            _inputActions.MapButtons.Enable();
            _inputActions.MapButtons.SelectBuild.performed += SelectBuild;
            _inputActions.MapButtons.SelectErase.performed += SelectErase;
            _inputActions.MapButtons.SelectWall.performed += SelectWall;
            _inputActions.MapButtons.SelectBridge.performed += SelectBridge;
        }
        else
        {
            _inputActions.MapButtons.Disable();
            _inputActions.MapButtons.SelectBuild.performed -= SelectBuild;
            _inputActions.MapButtons.SelectErase.performed -= SelectErase;
            _inputActions.MapButtons.SelectWall.performed -= SelectWall;
            _inputActions.MapButtons.SelectBridge.performed -= SelectBridge;
        }
    }

    private void SelectBridge(InputAction.CallbackContext obj)
    {
        foreach (GameEntity map in _maps)
        {
            map.ReplaceBuildType(BuildType.Bridge);
        }
    }
    
    private void SelectWall(InputAction.CallbackContext obj)
    {
        foreach (GameEntity map in _maps)
        {
            map.ReplaceBuildType(BuildType.Wall);
        }
    }

    private void SelectBuild(InputAction.CallbackContext obj)
    {
        foreach (GameEntity map in _maps)
        {
            map.ReplaceBuildingMode(BuildingMode.Build);
        }
    }

    private void SelectErase(InputAction.CallbackContext obj)
    {
        foreach (GameEntity map in _maps)
        {
            map.ReplaceBuildingMode(BuildingMode.Erase);
        }
    }

    public void UpdateEntities()
    {
        //todo: ось тут оновлювати
    }

    public void CleanupEntities()
    {
        
    }
}