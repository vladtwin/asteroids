using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;
using UnityEngine.Serialization;

namespace com.asteroids.scripts.Gameplay
{
    public class CameraFollow : MonoBehaviour
    {
        public CameraShaker Shaker;
        public Transform target;
        public float smoothSpeed = 0.125f;
        public Vector3 locationOffset;
        public bool UseBorders = true;

        public Vector2 BorderMaxMinX;
        public Vector2 BorderMaxMinY;
        public Camera gameCamera;
        
        private Vector2 viewSize;

        private void Start()
        {
           viewSize = new Vector2 (gameCamera.orthographicSize * gameCamera.aspect, gameCamera.orthographicSize);
        }
        
        private void FixedUpdate()
        {
            if (!target)
                return;
            
            Vector3 desiredPosition = target.position + target.rotation * locationOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            Shaker.RestPositionOffset = CalculatePositionInBorder(smoothedPosition);
        }

        private Vector3 CalculatePositionInBorder(Vector3 position)
        {
            if (!UseBorders)
                return position;
            
            position.x = Mathf.Clamp(position.x, BorderMaxMinX.x + viewSize.x, BorderMaxMinX.y - viewSize.x);
            position.y = Mathf.Clamp(position.y, BorderMaxMinY.y + viewSize.y, BorderMaxMinY.x - viewSize.y);
            
            return position;
        }
    }
}
