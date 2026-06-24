using UnityEngine;

namespace Code
{
    public sealed class SpawnParameters : MonoBehaviour
    {
        [SerializeField] public Transform positionSpawnEnemy;
        [SerializeField] public int count;
        [SerializeField] public PatrolRoute patrolRoute;
    }
}
