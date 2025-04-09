using Unity.Cinemachine;
using UnityEngine;

public interface ICameraService
{
    Camera MainCamera { get; set; }
    CinemachineCamera MainVirtualCamera { get; set; }
}