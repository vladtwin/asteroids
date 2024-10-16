using com.asteroids.scripts.Lobby.Game.Scripts.Lobby;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace asteroids.scripts
{
    public class LobbyUI : MonoBehaviour
    {
        public Button startButton;

        private MainLobbyState lobbyState;

        [Inject]
        public void Custruct(MainLobbyState lobbyState)
        {
            this.lobbyState = lobbyState;
        }
        void Start()
        {
            startButton.onClick.AddListener(()=>lobbyState.SetState(StateExitTypeEnum.ToGame));
        }

    }
}
