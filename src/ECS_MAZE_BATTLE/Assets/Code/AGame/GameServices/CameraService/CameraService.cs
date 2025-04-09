using Unity.Cinemachine;
using UnityEngine;

public class CameraService : ICameraService
{
    public Camera MainCamera { get; set; }
    public CinemachineCamera MainVirtualCamera { get; set; }
}