using UnityEngine;

namespace Code.Enemy
{
    public sealed class Enemy : MonoBehaviour
    {
        public void ReactToHit()
        {
            Destroy(gameObject);
        }
    }
}

