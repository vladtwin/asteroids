using asteroids.scripts;
using com.asteroids.scripts.Gameplay;
using com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public PlayerShipSettingsScriptable PlayerShipSettingsScriptable;
    public EnemySettingsScriptable EnemySettingsScriptable;
    public DefaultMapState DefaultMapState;
    public DefaultGameplayUI DefaultGameplayUI;
    
    public override void InstallBindings()
    {
        InstallSettings();

        Container.BindInterfacesAndSelfTo<GameplayServiceProvider>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<MainGameLogic>().AsSingle();
        Container.BindInterfacesAndSelfTo<DefaultGameplayUI>().FromInstance(DefaultGameplayUI).AsSingle();
        Container.Bind<IMapState>().FromInstance(DefaultMapState).AsSingle();
    }

    private void InstallSettings()
    {
        Container.BindInterfacesAndSelfTo<PlayerShipSettingsScriptable>().FromScriptableObject(PlayerShipSettingsScriptable).AsSingle();
        Container.BindInterfacesAndSelfTo<EnemySettingsScriptable>().FromScriptableObject(EnemySettingsScriptable).AsSingle();
    }
}

public class GameplayServiceProvider
{

    [Inject]
    public GameplayServiceProvider(IGameplayState gameplayState, IGameLogic gameLogic, IGameplayUI gameplayUI)
    {
        gameplayState.Configure(gameLogic, gameplayUI);
    }
}