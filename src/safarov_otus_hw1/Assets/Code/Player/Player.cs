using UnityEngine;

namespace Code
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviour _playerBehaviour;
        [SerializeField] private PlayerMovement _playerMovement;
        // [SerializeField] public StartSpawn startSpawn;

        public PlayerBehaviour PlayerBehaviour { get => _playerBehaviour; }
        public PlayerMovement PlayerMovement { get => _playerMovement; }
    }
}

