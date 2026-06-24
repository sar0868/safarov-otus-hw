using UnityEngine;

namespace Code
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviour playerBehaviour;
        [SerializeField] public StartSpawn startSpawn;

        public PlayerBehaviour PlayerBehaviour { get => playerBehaviour; }
    }
}

