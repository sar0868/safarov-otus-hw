using UnityEngine;

namespace Code
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviour _behaviour;
        [SerializeField] public StartSpawn startSpawn;

        // public StartSpawn Spawn()
        // {
        //     return _startSpawn;
        // }

    }
}

