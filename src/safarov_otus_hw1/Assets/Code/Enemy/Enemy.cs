using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Code
{
    public sealed class Enemy : MonoBehaviour
    {
        public List<Transform> locations;

        [SerializeField] private Transform _patrolRoute;
        [SerializeField] private Conditions _conditions;
        [SerializeField] private float _detectionRadus = 10.0f;
        [SerializeField] private float _attackDistance = 5.0f;
        [SerializeField] private int _hp = 3;


        private EnemyAttack _enemyAttack;
        private EnemyAnimation _animations;
        private int _locationIndex = 0;
        private NavMeshAgent _agent;
        private Vector3 _cashTarget;
        private bool _isDetected = false;
        private int _layerMaskPlayer;
        private string _playerLayer = "Player";
        private Collider[] _findPlayer;
        private bool _isDeath = false;

        public int Hp { get => _hp; set => _hp = value; }

        private void Start()
        {
            InitializePatrolRoute();
            _agent = GetComponent<NavMeshAgent>();
            _animations = GetComponent<EnemyAnimation>();
            _layerMaskPlayer = LayerMask.GetMask(_playerLayer);
            MoveToNextPatrolLocation();
            _findPlayer = new Collider[1];
            _enemyAttack = GetComponent<EnemyAttack>();
        }

        private void Update()
        {
            if (_isDeath == false)
            {
                if (_isDetected == false)
                {
                    if (_agent.remainingDistance < 0.2f && _agent.pathPending == false)
                    {
                        MoveToNextPatrolLocation();
                    }
                }
                StartCoroutine(ScanPlayer());
            }
        }

        private IEnumerator ScanPlayer()
        {
            yield return new WaitForSeconds(1f);
            if (Physics.OverlapSphereNonAlloc(
                transform.position,
                _detectionRadus,
                _findPlayer,
                _layerMaskPlayer) == 1)
            {
                _isDetected = true;
                Collider target = _findPlayer[0];
                Vector3 targetPosition = target.transform.position;
                _agent.ResetPath();
                _agent.destination = targetPosition;
                float distance = Mathf.Sqrt((targetPosition - transform.position).sqrMagnitude);
                if (distance <= _attackDistance)
                {
                    _enemyAttack.AttackPlayer();
                    _agent.isStopped = true;
                    _animations.AnimationAttack(true);
                }
                else
                {
                    _agent.isStopped = false;
                    _animations.AnimationAttack(false);
                }
            }
            else
            {
                if (_isDetected == true)
                {
                    _findPlayer[0] = null;
                    _isDetected = false;
                    _agent.ResetPath();
                    _agent.destination = _cashTarget;
                }
            }
        }

        private void MoveToNextPatrolLocation()
        {
            if (locations.Count == 0)
            {
                return;
            }
            _cashTarget = locations[_locationIndex].position;
            _agent.destination = _cashTarget;
            _locationIndex = (_locationIndex + 1) % locations.Count;
            _animations.AnimationWalk();
        }

        private void InitializePatrolRoute()
        {
            foreach (Transform item in _patrolRoute)
            {
                locations.Add(item);
            }
        }

        public void ReactToHit(int damage)
        {

            Damage(damage);
        }

        private void Damage(int damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                StartCoroutine(Die());
            }
        }

        private IEnumerator Die()
        {
            _conditions.KilledEnemy();
            _agent.isStopped = true;
            _animations.AnimationDeath();
            _isDeath = true;
            yield return new WaitForSeconds(3f);
            gameObject.SetActive(false);
            // Destroy(gameObject);
        }


    }
}
