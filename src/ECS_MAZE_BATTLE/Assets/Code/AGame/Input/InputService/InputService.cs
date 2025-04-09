using Code.Common.Entity;
using Code.Common.Extensions;
using Zenject;

public class InputService : IInputService
{
    private readonly ITouchscreenControl _actionsControl;
    private readonly IMapButtonsControl _mapButtonsControl;

    public InputService(ITouchscreenControl actionsControl, IMapButtonsControl mapButtonsControl)
    {
        _actionsControl = actionsControl;
        _mapButtonsControl = mapButtonsControl;
    }

    public void UpdateEntities()
    {
        _actionsControl.UpdateEntities();
        _mapButtonsControl.UpdateEntities();
    }
    
    public void ActionsControlSetActive(bool active)
    {
        _actionsControl.SetActive(active);
    }

    public void MapButtonsControlSetActive(bool active)
    {
        _mapButtonsControl.SetActive(active);
    }
}