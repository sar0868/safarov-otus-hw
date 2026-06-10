using UnityEngine;

namespace Code.Enemy
{
    public sealed class Enemy : MonoBehaviour
    {
        private WanderingAI _wanderingAI;

        private void Awake()
        {
            _wanderingAI = GetComponent<WanderingAI>();
        }

        public void Init(Transform patrolRoute)
        {
            _wanderingAI.patrolRoute = patrolRoute;
        }

        public void ReactToHit()
        {
            Destroy(gameObject);
        }
    }
}

