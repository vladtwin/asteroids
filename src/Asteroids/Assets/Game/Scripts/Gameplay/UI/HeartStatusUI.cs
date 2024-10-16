using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace asteroids.scripts
{
    public class HeartStatusUI : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> hearts;

        public void SetHeartCount(int heartCount)
        {
            for (var i = 0; i < hearts.Count; i++)
            {
                hearts[i].SetActive(i < heartCount);
            }
        }
    }
}
