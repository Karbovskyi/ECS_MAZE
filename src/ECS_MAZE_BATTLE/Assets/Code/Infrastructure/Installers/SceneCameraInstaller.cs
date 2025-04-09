using Unity.Cinemachine;
using UnityEngine;
using Zenject;

public class SceneCameraInstaller : MonoInstaller
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private CinemachineCamera _mainVirtualCamera;
    
    public override void InstallBindings()
    {
        ICameraService cameraService = Container.Resolve<ICameraService>();
        cameraService.MainCamera = _mainCamera;
        cameraService.MainVirtualCamera = _mainVirtualCamera;
    }
}