using UnityEngine;

namespace asteroids.scripts
{
    public class InfinityBackground : MonoBehaviour
    {
        public float MaxDistance = 100f;

        
        public GameObject background1;
        public GameObject background2;

        public Vector3 distance;
        public void Update()
        {
        
            if (transform.position.y > background1.transform.position.y + MaxDistance && Vector3.Distance(transform.position, background1.transform.position) > MaxDistance)
                background1.transform.position =  background2.transform.position + new Vector3(0, MaxDistance, 0);

            if (transform.position.y > background2.transform.position.y + MaxDistance  &&
                Vector3.Distance(transform.position, background2.transform.position) > MaxDistance)
                background2.transform.position = background1.transform.position + new Vector3(0, MaxDistance, 0);
        }

        private Vector3 CalculatePosition()
        {
            var y = ((transform.position.y / MaxDistance) + 1) * MaxDistance;
            return new Vector3(0, y, 0);
        }
    }
}