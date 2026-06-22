using System;
using UnityEngine;
using UnityEngine.AI;

namespace Code
{
    public sealed class EnemyAttack : MonoBehaviour
    {
        // Когда игрок находится в зоне 10f, то enemy начинает движение к нему, в зоне 1f атака 
        // нанесение ущерба 
        // Поиск игрока по лучу

        [SerializeField] private PlayerBehaviour _player;
        [SerializeField] private float _detectionRadus = 10.0f;
        [SerializeField] private float _attackRadus = 1.0f;
        [SerializeField] private int _damage = 1;
        private Animator _animator;
        private NavMeshAgent _agent;
        private bool _isDetected = false;
        private int _layerMaskPlayer;
        private string _playerLayer = "Player";
        private Collider[] _findPlayer;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _layerMaskPlayer = LayerMask.GetMask(_playerLayer);
            _findPlayer = new Collider[1];
        }

        private void Update()
        {
            if (_isDetected == false)
            {
                ScanPlayer();
            }
            // OnDrawGizmos();
        }

        private void ScanPlayer()
        {
            // Collider[] hitColliders = Physics.OverlapSphere(transform.position, _detectionRadus, _layerMaskPlayer);
            if (Physics.OverlapSphereNonAlloc(transform.position, _detectionRadus, _findPlayer, _layerMaskPlayer) == 1)
            {
                _isDetected = true;
                Collider target = _findPlayer[0];
                Vector3 targetPosition = target.transform.position;
                _agent.destination = targetPosition;
            }
            else
            {
                _isDetected = false;
            }
        }

        // private void OnDrawGizmos()
        // {
        //     Gizmos.color = Color.red;
        //     Gizmos.DrawWireSphere(transform.position, _detectionRadus);
        // }
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