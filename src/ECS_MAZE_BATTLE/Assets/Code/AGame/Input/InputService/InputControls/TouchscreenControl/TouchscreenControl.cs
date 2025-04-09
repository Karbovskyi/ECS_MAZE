using Code.Common.Entity;
using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchscreenControl : ITouchscreenControl
{
    private readonly IGroup<InputEntity> _inputs;
    private readonly IGroup<InputEntity> _secondTouches;
    private readonly InputActions _inputActions;

    private bool _hasFirstTouch;
    private bool _hasSecondTouch;
    
    public TouchscreenControl(InputActions inputActions, InputContext inputContext)
    {
        _inputActions = inputActions;
        _inputs = inputContext.GetGroup(InputMatcher.Input);
        
    }
    
    public void SetActive(bool active)
    {
        if (active)
        {
            _inputActions.Inputs.Enable();
            _inputActions.Inputs.StartFirstTouch.started += CreateFirstTouch;
            _inputActions.Inputs.StartFirstTouch.canceled += DestroyFirstTouch;
            _inputActions.Inputs.StartSecondTouch.started += CreateSecondTouch;
            _inputActions.Inputs.StartSecondTouch.canceled += DestroySecondTouch;
        }
        else
        {
            _inputActions.Inputs.Disable();
            _inputActions.Inputs.StartFirstTouch.started -= CreateFirstTouch;
            _inputActions.Inputs.StartFirstTouch.canceled -= DestroyFirstTouch;
            _inputActions.Inputs.StartSecondTouch.started -= CreateSecondTouch;
            _inputActions.Inputs.StartSecondTouch.canceled -= DestroySecondTouch;
            
            _hasFirstTouch = false;
            _hasSecondTouch = false;
        }
    }
    
    public void UpdateEntities()
    {
        foreach (InputEntity input in _inputs)
        {
            if (_hasFirstTouch)
            {
                input.ReplaceFirstTouch(GetFirstTouchPosition());
            }
            else if (input.hasFirstTouch)
            {
                input.RemoveFirstTouch();
            }
            
            if (_hasSecondTouch)
            {
                input.ReplaceSecondTouch(GetSecondTouchPosition());
            }
            else if (input.hasSecondTouch)
            {
                input.RemoveSecondTouch();
            }
        }
    }

    private void CreateFirstTouch(InputAction.CallbackContext obj)
    {
        if (MyInputExtensions.IsPointerOverUIObject(GetFirstTouchPosition()))
            return;
        
        _hasFirstTouch = true;
    }

    private void CreateSecondTouch(InputAction.CallbackContext obj)
    {
        if (MyInputExtensions.IsPointerOverUIObject(GetSecondTouchPosition()))
            return;
        
        _hasSecondTouch = true;
    }

    private Vector2 GetFirstTouchPosition()
    {
        return _inputActions.Inputs.FirstTouchPosition.ReadValue<Vector2>();
    }

    private Vector2 GetSecondTouchPosition()
    {
        return _inputActions.Inputs.SecondTouchPosition.ReadValue<Vector2>();
    }

    private void DestroyFirstTouch(InputAction.CallbackContext obj)
    {
        _hasFirstTouch = false;
    }

    private void DestroySecondTouch(InputAction.CallbackContext obj)
    {
        _hasSecondTouch = false;
    }
}