using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay
{
    public class GameFinishMenu : MonoBehaviour
    {
        public Button RetryButton;
        public Button FinishButton;

        public GameObject WinBackground;
        public GameObject LoseBackground;

        [FormerlySerializedAs("KilledEnemy")] public TextMeshPro FinishText;
        
        private GameFinishPlayerAction exitType;

        public void ConfigureButtons()
        {
            RetryButton.onClick.AddListener(() => exitType = GameFinishPlayerAction.Retry);
            FinishButton.onClick.AddListener(() => exitType = GameFinishPlayerAction.Finish);
        }

        public async UniTask<GameFinishPlayerAction> WaitForAction(GameFinishType gameFinishType)
        {
            ConfigureButtons();
            WinBackground.SetActive(gameFinishType.IsWin);
            LoseBackground.SetActive(!gameFinishType.IsWin);
            FinishText.text = gameFinishType.IsWin ? "You Win!" : "You Lose!";
            
            await UniTask.WhenAny(
                RetryButton.OnClickAsync(),
                FinishButton.OnClickAsync());

            return exitType;
        }
    }
}