// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// namespace Code
// {
//     public sealed class EnemyMovement : MonoBehaviour
//     {
//         public List<Transform> locations;

//         [SerializeField] private float _detectionRadus = 10.0f;
//         [SerializeField] private float _attackDistance = 5.0f;

//         private EnemyAttack _enemyAttack;
//         private EnemyAnimation _animations;
//         private int _locationIndex = 0;
//         private NavMeshAgent _agent;
//         private Vector3 _cashTarget;
//         private bool _isDetected = false;
//         private int _layerMaskPlayer;
//         private string _playerLayer = "Player";
//         private Collider[] _findPlayer;
//         private bool _isDeath = false;


//         private void Start()
//         {
//             InitializePatrolRoute();
//             _agent = GetComponent<NavMeshAgent>();
//             _animations = GetComponent<EnemyAnimation>();
//             _layerMaskPlayer = LayerMask.GetMask(_playerLayer);
//             MoveToNextPatrolLocation();
//             _findPlayer = new Collider[1];
//             _enemyAttack = GetComponent<EnemyAttack>();
//         }

//         private void Update()
//         {
//             if (_isDeath == false)
//             {
//                 if (_isDetected == false)
//                 {
//                     if (_agent.remainingDistance < 0.2f && _agent.pathPending == false)
//                     {
//                         MoveToNextPatrolLocation();
//                     }
//                 }
//                 StartCoroutine(ScanPlayer());
//             }
//         }

//         private IEnumerator ScanPlayer()
//         {
//             yield return new WaitForSeconds(1f);
//             if (Physics.OverlapSphereNonAlloc(
//                 transform.position,
//                 _detectionRadus,
//                 _findPlayer,
//                 _layerMaskPlayer) == 1)
//             {
//                 _isDetected = true;
//                 Collider target = _findPlayer[0];
//                 Vector3 targetPosition = target.transform.position;
//                 _agent.ResetPath();
//                 _agent.destination = targetPosition;
//                 float distance = Mathf.Sqrt((targetPosition - transform.position).sqrMagnitude);
//                 if (distance <= _attackDistance)
//                 {
//                     _enemyAttack.AttackPlayer();
//                     AgentState(true);
//                     _animations.AnimationAttack(true);
//                 }
//                 else
//                 {
//                     AgentState(false);
//                     _animations.AnimationAttack(false);
//                 }
//             }
//             else
//             {
//                 if (_isDetected == true)
//                 {
//                     _findPlayer[0] = null;
//                     _isDetected = false;
//                     _agent.ResetPath();
//                     _agent.destination = _cashTarget;
//                 }
//             }
//         }

//         private void MoveToNextPatrolLocation()
//         {
//             if (locations.Count == 0)
//             {
//                 return;
//             }
//             _cashTarget = locations[_locationIndex].position;
//             _agent.destination = _cashTarget;
//             _locationIndex = (_locationIndex + 1) % locations.Count;
//             _animations.AnimationWalk();
//         }

//         private void InitializePatrolRoute()
//         {
//             foreach (Transform item in _patrolRoute)
//             {
//                 locations.Add(item);
//             }
//         }

//         public void AgentState(bool agentState)
//         {
//             _agent.isStopped = agentState;
//         }

//         public void Init(Transform patrolRoute, Conditions conditions, Player player)
//         {
//             _patrolRoute = patrolRoute;
//             _enemy.Conditions = conditions;
//             _enemyAttack.Player = player.playerBehaviour;
//         }
//     }
// }
