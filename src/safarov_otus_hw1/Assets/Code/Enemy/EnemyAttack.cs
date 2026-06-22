using System;
using UnityEngine;
using UnityEngine.AI;

namespace Code
{
    public sealed class EnemyAttack : MonoBehaviour
    {
        // Когда игрок находится в зоне 5f, то enemy начинает движение к нему, в зоне 1f атака 
        // нанесение ущерба 
        // Поиск игрока по лучу

        [SerializeField] private PlayerBehaviour _player;
        [SerializeField] private float _detectionRadus = 5.0f;
        [SerializeField] private float _attackRadus = 1.0f;
        [SerializeField] private int _damage = 1;
        private Animator _animator;
        private NavMeshAgent _agent;
        private bool _isDetected = false;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (_isDetected == false)
            {
                ScanPlayer();
            }
        }

        private void ScanPlayer()
        {
            // RaycastHit hit =
        }
    }
}

// RaycastHit[] hits = Physics.SphereCastAll(transform.position, _radius, transform.forward, _currentDistance, _targetLayers);
// if (hits != null)
// {
//     foreach (RaycastHit hit in hits)
//     {
//         if (hit.collider.CompareTag("NPC"))
//         {
//             _conditions.KillNPC();
//         }

//         Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
//         if (enemy != null)
//         {
//             enemy.ReactToHit(_damage);
//         }
//     }
// }