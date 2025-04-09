using Code.AAAGame.Map.MapFeature.WallsFactory;
using Code.AAAGame.Map.MapService;
using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Physics;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Common.Time;
using Code.Gameplay.StaticData;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Factory;
using RSG;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
  {
    public override void InstallBindings()
    {
      BindInputService();
      BindInfrastructureServices();
      BindAssetManagementServices();
      BindCommonServices();
      BindSystemFactory();
      BindContexts();
      BindGameplayServices();
      BindGameplayFactories();
      BindStateMachine();
      BindStateFactory();
      BindGameStates();
    }

    private void BindInputService()
    {
      Container.Bind<InputActions>().AsSingle();
      Container.Bind<ITouchscreenControl>().To<TouchscreenControl>().AsSingle();
      Container.Bind<IMapButtonsControl>().To<MapButtonsControl>().AsSingle();
      Container.Bind<IInputService>().To<InputService>().AsSingle();
    }

    private void BindInfrastructureServices()
    {
      Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
      Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
    }

    private void BindAssetManagementServices()
    {
      Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
    }

    private void BindCommonServices()
    {
      Container.Bind<IRandomService>().To<UnityRandomService>().AsSingle();
      Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
      Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
      Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
    }

    private void BindSystemFactory()
    {
      Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
    }

    private void BindContexts()
    {
      Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
      
      Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
      Container.Bind<InputContext>().FromInstance(Contexts.sharedInstance.input).AsSingle();
      Container.Bind<MetaContext>().FromInstance(Contexts.sharedInstance.meta).AsSingle();
    }

    private void BindGameplayServices()
    {
      Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
      Container.Bind<IMapService>().To<MapService>().AsSingle();
      Container.Bind<ICameraService>().To<CameraService>().AsSingle();
    }

    private void BindGameplayFactories()
    {
      Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
      Container.Bind<IWallFactory>().To<WallFactory>().AsSingle();
    }

    private void BindStateMachine()
    {
      Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
    }

    private void BindStateFactory()
    {
      Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
    }

    private void BindGameStates()
    {
      Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
      Container.BindInterfacesAndSelfTo<LoadingMapState>().AsSingle();
      Container.BindInterfacesAndSelfTo<MapEnterState>().AsSingle();
      Container.BindInterfacesAndSelfTo<MapLoopState>().AsSingle();
    }

    public void Initialize()
    {
      Promise.UnhandledException += LogPromiseException;
      Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
    }

    private void LogPromiseException(object sender, ExceptionEventArgs e)
    {
      Debug.LogError(e.Exception);
    }
  }
}