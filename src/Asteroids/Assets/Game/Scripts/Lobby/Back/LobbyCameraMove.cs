using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace asteroids.scripts
{
    public class LobbyCameraMove : MonoBehaviour
    {

        public Vector3 Speed;
        void Update()
        {
            transform.Translate(Speed * Time.deltaTime, Space.World);
        }
    }
}
