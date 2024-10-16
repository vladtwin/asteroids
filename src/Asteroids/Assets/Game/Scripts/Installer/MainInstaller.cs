using com.asteroids.Gameplay.PlayerInputSystem.Inject;
using com.asteroids.scripts.Gameplay;
using com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay;
using com.asteroids.scripts.Installer.Game.Scripts.Installer;
using com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine;
using com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine.Inject;
using Zenject;

public class MainInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {
        InstallGameStateMachine();
        InstallGameComponents();
    }
    
    private void InstallGameComponents()
    {
      
        Container.BindPlayerInputSystem();
    }
    
    private void InstallGameStateMachine()
    {
        Container.BindInterfacesAndSelfTo<StateMachineBootstrap>().AsSingle();
        Container.DiStateMachine().BindStateMachine<ApplicationStateMachine>()
            .BindState<LoadingState>()
            .BindState<MainLobbyState>()
            .BindState<GameplayState>();

    }
}