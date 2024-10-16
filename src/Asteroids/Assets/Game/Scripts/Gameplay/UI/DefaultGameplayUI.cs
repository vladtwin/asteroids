using System;
using System.Threading.Tasks;
using asteroids.scripts;
using TMPro;
using UnityEngine;
using Zenject;

namespace com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay
{
    public class DefaultGameplayUI : MonoBehaviour, IGameplayUI
    {
        public GameFinishMenu GameFinishMenu;
        public GameObject InputController;
        public HeartStatusUI HeartStatusUI;
        public TMP_Text EnemyKilled;
        private IMapState mapState;
        private int enemyKilled;

        [Inject]
        public void Construct(IMapState mapState)
        {
            this.mapState = mapState;
        }

        public async Task<GameFinishPlayerAction> WaitForPlayerAction(GameFinishType gameFinish)
        {
            try
            {
                HeartStatusUI.gameObject.SetActive(false);
                InputController.SetActive(false);
                GameFinishMenu.gameObject.SetActive(true);
                return await GameFinishMenu.WaitForAction(gameFinish);
            }
            finally
            {
                HeartStatusUI.gameObject.SetActive(true);
                GameFinishMenu.gameObject.SetActive(false);
                InputController.SetActive(true);
            }
        }

        public void Update()
        {
            HeartStatusUI.SetHeartCount(mapState.LifeCount);

            if (enemyKilled != mapState.KilledCount)
            {
                enemyKilled = mapState.KilledCount;
                EnemyKilled.text = mapState.KilledCount.ToString();
            }
        }
    }
}